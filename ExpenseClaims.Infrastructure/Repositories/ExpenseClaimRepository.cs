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

        public ExpenseClaimRepository(IRepositoryAsync<ExpenseClaim> repository)
        {
            _repository = repository;
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
            return await _repository.Entities.Include(c => c.Items)
                                                .ThenInclude(i => i.Currency)
                                            .Include(c => c.Items)
                                                .ThenInclude(i => i.Category)
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync(c => c.Id == claimId);
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
