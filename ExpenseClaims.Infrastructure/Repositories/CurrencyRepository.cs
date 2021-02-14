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
    public class CurrencyRepository : RepositoryAsync<Currency>, ICurrencyRepository
    {
        public CurrencyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
