using ExpenseClaims.Client.Services.Base;
using ExpenseClaims.Client.Features.ExpenseCategory.Commands.Create;
using ExpenseClaims.Client.Features.ExpenseCategory.Commands.Update;
using ExpenseClaims.Client.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Contracts
{
    public interface IExpenseCategoryService
    {
        Task<List<ExpenseCategoryListVM>> GetAllExpenseCategories();
        Task<ExpenseCategoryDetailVM> GetExpenseCategoryById(int id);
        Task<ApiResponse<int>> CreateExpenseCategory(CreateExpenseCategoryFrontCommand category);
        Task<ApiResponse<int>> UpdateExpenseCategory(int id, UpdateExpenseCategoryFrontCommand category);
        Task<ApiResponse<int>> DeleteExpenseCategory(int id);
    }
}
