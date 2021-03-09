using ExpenseClaims.Client.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Contracts
{
    public interface IExpenseItemService
    {
        Task<List<GetAllExpenseItemsResponse>> GetAllExpenseItems();
        Task<GetExpenseItemByIdResponse> GetExpenseItemById(int id);
        Task<ApiResponse<int>> CreateExpenseItem(CreateExpenseItemCommand item);
        Task<ApiResponse<int>> UpdateExpenseItem(UpdateExpenseItemCommand item);
        Task<ApiResponse<int>> DeleteExpenseItem(int id);
    }
}
