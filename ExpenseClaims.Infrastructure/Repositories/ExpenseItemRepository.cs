using ExpenseClaims.Application.Interfaces.Repositories;
using ExpenseClaims.Domain.Entities.Catalog;
using ExpenseClaims.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseClaims.Infrastructure.Repositories
{
    public class ExpenseItemRepository : IExpenseItemRepository
    {
        private readonly IRepositoryAsync<ExpenseItem> _repository;
        private readonly ApplicationDbContext _context;

        public ExpenseItemRepository(IRepositoryAsync<ExpenseItem> repository, ApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        public IQueryable<ExpenseItem> Items => _repository.Entities;

        public async Task<List<ExpenseItem>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<ExpenseItem> GetByIdAsync(int itemId)
        {
            return await _repository.Entities.Include(i => i.Currency)
                                             .Include(i => i.Category).FirstOrDefaultAsync(i => i.Id == itemId);
        }

        public async Task<int> InsertAsync(ExpenseItem item)
        {
            await _repository.AddAsync(item);
            return item.Id;
        }

        public async Task UpdateAsync(ExpenseItem item)
        {
            await _repository.UpdateAsync(item);
        }

        public async Task DeleteAsync(ExpenseItem item)
        {
            await _repository.DeleteAsync(item);
        }
    }
}
