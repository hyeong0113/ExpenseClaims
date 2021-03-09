using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.ViewModels
{
    public class ExpenseItemListVM
    {
        public int Id { get; set; }

        public int ClaimId { get; set; }

        public int CategoryId { get; set; }

        public int CurrencyId { get; set; }

        public string Payee { get; set; }

        public System.DateTimeOffset Date { get; set; }

        public string Description { get; set; }

        public double Amount { get; set; }

        public double UsdAmount { get; set; }

        public ExpenseCategoryDetailVM Category { get; set; }

        public CurrencyDetailVM Currency { get; set; }
    }
}
