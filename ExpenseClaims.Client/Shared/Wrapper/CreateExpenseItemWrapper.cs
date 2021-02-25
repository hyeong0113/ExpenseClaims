using ExpenseClaims.Application.Features.Currencies.Quries.GetAll;
using ExpenseClaims.Application.Features.ExpenseCategories.Quries.GetAll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Shared.Wrapper
{
    public class CreateExpenseItemWrapper
    {
        public int ClaimId { get; set; }
        public GetAllExpenseCategoriesResponse Category { get; set; }
        public GetAllCurrenciesResponse Currency { get; set; }
        public string Payee { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal USDAmount { get; set; }
    }
}
