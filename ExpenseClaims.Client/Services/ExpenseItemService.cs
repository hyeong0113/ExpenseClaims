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

namespace ExpenseClaims.Client.Services
{
    public class ExpenseItemService : BaseDataService, IExpenseItemService
    {
        private readonly IMapper _mapper;

        public ExpenseItemService(IBaseClient client, IMapper mapper, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }

        public async Task<List<ExpenseItemListVM>> GetAllExpenseItems()
        {
            await AddBearerToken();

            var itemList = await _client.GetAllExpenseItemsAsync(ApiVersion.apiVersion);
            var mappedItemList = _mapper.Map<IEnumerable<ExpenseItemListVM>>(itemList.Data);
            return mappedItemList.ToList();
        }

        public async Task<ExpenseItemDetailVM> GetExpenseItemById(int id)
        {
            await AddBearerToken();

            var item = await _client.GetExpenseItemByIdAsync(id, ApiVersion.apiVersion);
            var mappedItem = _mapper.Map<ExpenseItemDetailVM>(item.Data);
            return mappedItem;
        }

        public async Task<ApiResponse<int>> CreateExpenseItem(ExpenseItemDetailVM item)
        {
            try
            {
                await AddBearerToken();
                var mappedItem = _mapper.Map<CreateExpenseItemCommand>(item);
                var response = await _client.CreateExpenseItemAsync(ApiVersion.apiVersion, mappedItem);
                return new ApiResponse<int>() { Data = response.Data, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<ApiResponse<int>> UpdateExpenseItem(int id, ExpenseItemDetailVM item)
        {
            try
            {
                await AddBearerToken();
                var mappedItem = _mapper.Map<UpdateExpenseItemCommand>(item);
                var response = await _client.UpdateExpenseItemAsync(id, ApiVersion.apiVersion, mappedItem);
                return new ApiResponse<int>() { Data = response.Data, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<ApiResponse<int>> DeleteExpenseItem(int id)
        {
            try
            {
                await AddBearerToken();
                var response = await _client.DeleteExpenseItemAsync(id, ApiVersion.apiVersion);
                return new ApiResponse<int>() { Data = response.Data, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
