using ExpenseClaims.Client.Services.Base;
using ExpenseClaims.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Contracts
{
    public interface IExpenseCategoryService
    {
        Task<List<ExpenseCategoryListVM>> GetAllExpenseCategories();
        Task<ExpenseCategoryDetailVM> GetExpenseCategoryById(int id);
        Task<ApiResponse<int>> CreateExpenseCategory(ExpenseCategoryDetailVM category);
        Task<ApiResponse<int>> UpdateExpenseCategory(int id, ExpenseCategoryDetailVM category);
        Task<ApiResponse<int>> DeleteExpenseCategory(int id);
    }
}
