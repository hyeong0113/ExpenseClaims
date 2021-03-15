using AutoMapper;
using Blazored.LocalStorage;
using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.Services.Constant;
using ExpenseClaims.Client.Services.Base;
using ExpenseClaims.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;

namespace ExpenseClaims.Client.Services
{
    public class ExpenseClaimService : BaseDataService, IExpenseClaimService
    {
        private readonly IMapper _mapper;

        public ExpenseClaimService(IBaseClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<ExpenseClaimListVM>> GetAllExpenseClaims(Claim role)
        {
            await AddBearerToken();

            var fetchedClaimList = await _client.GetAllExpenseClaimsAsync(ApiVersion.apiVersion);

            IEnumerable<GetAllExpenseClaimsResponse> claimList = null;

            if (role.Value.Contains("Approver"))
            {
                claimList = fetchedClaimList.Data.Where(c => c.Status == Status.SUBMITTED).Union(fetchedClaimList.Data.Where(c => c.Status == Status.RESUBMITTED));
            }
            else if (role.Value.Contains("Financer"))
            {
                claimList = fetchedClaimList.Data.Where(c => c.Status == Status.APPROVED);
            }
            else
            {
                claimList = fetchedClaimList.Data;
            }

            var mappedClaimList = _mapper.Map<IEnumerable<ExpenseClaimListVM>>(claimList);
            return mappedClaimList.ToList();
        }

        public async Task<ExpenseClaimDetailVM> GetExpenseClaimById(int id)
        {
            await AddBearerToken();

            var claim = await _client.GetExpenseClaimByIdAsync(id, ApiVersion.apiVersion);
            var mappedClaim = _mapper.Map<ExpenseClaimDetailVM>(claim.Data);
            return mappedClaim;
        }

        public async Task<ApiResponse<int>> CreateExpenseClaim(ExpenseClaimDetailVM claim)
        {
            try
            {
                await AddBearerToken();
                var mappedClaim = _mapper.Map<CreateExpenseClaimCommand>(claim);
                var response = await _client.CreateExpenseClaimAsync(ApiVersion.apiVersion, mappedClaim);
                return new ApiResponse<int>() { Data = response.Data, Success = true};
            }
            catch(ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<ApiResponse<int>> UpdateExpenseClaim(int id, ExpenseClaimDetailVM claim)
        {
            try
            {
                await AddBearerToken();
                var mappedClaim = _mapper.Map<UpdateExpenseClaimCommand>(claim);
                var response = await _client.UpdateExpenseClaimAsync(id, ApiVersion.apiVersion, mappedClaim);
                return new ApiResponse<int>() { Data = response.Data, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<ApiResponse<int>> DeleteExpenseClaim(int id)
        {
            try
            {
                await AddBearerToken();
                var response = await _client.DeleteExpenseClaimAsync(id, ApiVersion.apiVersion);
                return new ApiResponse<int>() { Data = response.Data, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
