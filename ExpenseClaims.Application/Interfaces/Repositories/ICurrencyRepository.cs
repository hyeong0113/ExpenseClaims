using ExpenseClaims.Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseClaims.Application.Interfaces.Repositories
{
    public interface ICurrencyRepository : IRepositoryAsync<Currency>
    {
    }
}
