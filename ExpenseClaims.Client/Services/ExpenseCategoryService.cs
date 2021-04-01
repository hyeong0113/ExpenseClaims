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
using ExpenseClaims.Client.Services.Features.ExpenseCategoryService.Commands.Create;
using ExpenseClaims.Client.Services.Features.ExpenseCategoryService.Commands.Update;

namespace ExpenseClaims.Client.Services
{
    public class ExpenseCategoryService : BaseDataService, IExpenseCategoryService
    {
        private readonly IMapper _mapper;

        public ExpenseCategoryService(IMapper mapper, IBaseClient client, ILocalStorageService localStorage) : base(client, localStorage)
        {
            _mapper = mapper;
        }


        public async Task<List<ExpenseCategoryListVM>> GetAllExpenseCategories()
        {
            await AddBearerToken();

            var categoryList = await _client.GetAllExpenseCategoriesAsync(ApiVersion.apiVersion);
            var mappedCategoryList = _mapper.Map<IEnumerable<ExpenseCategoryListVM>>(categoryList.Data);
            return mappedCategoryList.ToList();
        }

        public async Task<ExpenseCategoryDetailVM> GetExpenseCategoryById(int id)
        {
            await AddBearerToken();

            var category = await _client.GetExpenseCategoryByIdAsync(id, ApiVersion.apiVersion);
            var mappedCategory = _mapper.Map<ExpenseCategoryDetailVM>(category.Data);
            return mappedCategory;
        }

        public async Task<ApiResponse<int>> CreateExpenseCategory(CreateExpenseCategoryFrontCommand category)
        {
            try
            {
                await AddBearerToken();
                var mappedCategory = _mapper.Map<CreateExpenseCategoryCommand>(category);
                var response = await _client.CreateExpenseCategoryAsync(ApiVersion.apiVersion, mappedCategory);
                return new ApiResponse<int>() { Data = response.Data, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<ApiResponse<int>> UpdateExpenseCategory(int id, UpdateExpenseCategoryFrontCommand category)
        {
            try
            {
                await AddBearerToken();
                var mappedCategory = _mapper.Map<UpdateExpenseCategoryCommand>(category);
                var response = await _client.UpdateExpenseCategoryAsync(id, ApiVersion.apiVersion, mappedCategory);
                return new ApiResponse<int>() { Data = response.Data, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }

        public async Task<ApiResponse<int>> DeleteExpenseCategory(int id)
        {
            try
            {
                await AddBearerToken();
                var response = await _client.DeleteExpenseCategoryAsync(id, ApiVersion.apiVersion);
                return new ApiResponse<int>() { Data = response.Data, Success = true };
            }
            catch (ApiException ex)
            {
                return ConvertApiExceptions<int>(ex);
            }
        }
    }
}
