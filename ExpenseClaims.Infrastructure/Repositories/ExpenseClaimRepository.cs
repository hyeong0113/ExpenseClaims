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
    public class ExpenseClaimRepository : IExpenseClaimRepository
    {
        private readonly IRepositoryAsync<ExpenseClaim> _repository;
        private readonly IExpenseItemRepository _itemRepository;

        public ExpenseClaimRepository(IRepositoryAsync<ExpenseClaim> repository, IExpenseItemRepository itemRepository)
        {
            _repository = repository;
            _itemRepository = itemRepository;
        }

        public IQueryable<ExpenseClaim> Claims => _repository.Entities;

        public async Task<List<ExpenseClaim>> GetListAsync()
        {
            return await _repository.Entities.ToListAsync();
        }

        public async Task<ExpenseClaim> GetByIdAsync(int claimId)
        {
            return await _repository.Entities.Where(c => c.Id == claimId).FirstOrDefaultAsync();
        }

        public async Task<ExpenseClaim> GetByIdWithItemsAsync(int claimId)
        {
            return await _repository.Entities.Include(c => c.Items).FirstOrDefaultAsync(c => c.Id == claimId);
        }

        public async Task<int> InsertAsync(ExpenseClaim claim)
        {
            await _repository.AddAsync(claim);
            return claim.Id;
        }

        public async Task UpdateAsync(ExpenseClaim claim)
        {
            await _repository.UpdateAsync(claim);
        }

        public async Task DeleteAsync(ExpenseClaim claim)
        {
            await _repository.DeleteAsync(claim);
        }

    }
}
