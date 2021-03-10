using ExpenseClaims.Client.Services.Base;
using ExpenseClaims.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Contracts
{
    public interface IExpenseItemService
    {
        Task<List<ExpenseItemListVM>> GetAllExpenseItems();
        Task<ExpenseItemDetailVM> GetExpenseItemById(int id);
        Task<ApiResponse<int>> CreateExpenseItem(ExpenseItemDetailVM item);
        Task<ApiResponse<int>> UpdateExpenseItem(int id, ExpenseItemDetailVM item);
        Task<ApiResponse<int>> DeleteExpenseItem(int id);
    }
}
