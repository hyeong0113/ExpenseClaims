using ExpenseClaims.Client.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Contracts
{
    public interface IExpenseCategoryService
    {
        Task<List<GetAllExpenseCategoriesResponse>> GetAllExpenseCategories();
        Task<GetExpenseCategoryByIdResponse> GetExpenseCategoryById(int id);
        Task<ApiResponse<int>> CreateExpenseCategory(CreateExpenseCategoryCommand category);
        Task<ApiResponse<int>> UpdateExpenseCategory(UpdateExpenseCategoryCommand category);
        Task<ApiResponse<int>> DeleteExpenseCategory(int id);
    }
}
