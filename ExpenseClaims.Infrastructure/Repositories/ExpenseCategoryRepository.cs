using ExpenseClaims.Application.Interfaces.Repositories;
using ExpenseClaims.Domain.Entities.Catalog;
using ExpenseClaims.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseClaims.Infrastructure.Repositories
{
    public class ExpenseCategoryRepository : RepositoryAsync<ExpenseCategory>, IExpenseCategoryRepository
    {
        public ExpenseCategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
