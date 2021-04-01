using ExpenseClaims.Client.Services.Base;
using ExpenseClaims.Client.Services.Features.ExpenseCategoryService.Commands.Create;
using ExpenseClaims.Client.Services.Features.ExpenseCategoryService.Commands.Update;
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
        Task<ApiResponse<int>> CreateExpenseCategory(CreateExpenseCategoryFrontCommand category);
        Task<ApiResponse<int>> UpdateExpenseCategory(int id, UpdateExpenseCategoryFrontCommand category);
        Task<ApiResponse<int>> DeleteExpenseCategory(int id);
    }
}
