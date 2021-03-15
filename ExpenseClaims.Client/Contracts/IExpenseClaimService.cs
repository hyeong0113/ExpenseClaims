using ExpenseClaims.Client.Services.Base;
using ExpenseClaims.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Contracts
{
    public interface IExpenseClaimService
    {
        Task<List<ExpenseClaimListVM>> GetAllExpenseClaims(Claim role);
        Task<ExpenseClaimDetailVM> GetExpenseClaimById(int id);
        Task<ApiResponse<int>> CreateExpenseClaim(ExpenseClaimDetailVM claim);
        Task<ApiResponse<int>> UpdateExpenseClaim(int id, ExpenseClaimDetailVM claim);
        Task<ApiResponse<int>> DeleteExpenseClaim(int id);
    }
}
