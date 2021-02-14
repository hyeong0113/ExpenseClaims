using ExpenseClaims.Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseClaims.Application.Interfaces.Repositories
{
    public interface IExpenseClaimRepository
    {
        IQueryable<ExpenseClaim> Claims { get; }

        Task<List<ExpenseClaim>> GetListAsync();

        Task<ExpenseClaim> GetByIdAsync(int claimId);

        Task<ExpenseClaim> GetByIdWithItemsAsync(int claimId);

        Task<int> InsertAsync(ExpenseClaim claim);

        Task UpdateAsync(ExpenseClaim claim);

        Task DeleteAsync(ExpenseClaim claim);
    }
}
