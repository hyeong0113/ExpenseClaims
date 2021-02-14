using ExpenseClaims.Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseClaims.Application.Interfaces.Repositories
{
    public interface IExpenseItemRepository
    {
        IQueryable<ExpenseItem> Items { get; }

        Task<List<ExpenseItem>> GetListAsync();

        Task<ExpenseItem> GetByIdAsync(int itemId);

        Task<int> InsertAsync(ExpenseItem claim);

        Task UpdateAsync(ExpenseItem claim);

        Task DeleteAsync(ExpenseItem claim);
    }
}
