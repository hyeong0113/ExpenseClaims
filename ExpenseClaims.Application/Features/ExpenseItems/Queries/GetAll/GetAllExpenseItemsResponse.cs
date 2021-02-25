using ExpenseClaims.Application.Features.Currencies.Quries.GetById;
using ExpenseClaims.Application.Features.ExpenseCategories.Quries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseClaims.Application.Features.ExpenseItems.Queries.GetAll
{
    public class GetAllExpenseItemsResponse
    {
        public int Id { get; set; }
        public int ClaimId { get; set; }
        public int CategoryId { get; set; }
        public int CurrencyId { get; set; }
        public string Payee { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal USDAmount { get; set; }

        public GetExpenseCategoryByIdResponse Category { get; set; }
        public GetCurrencyByIdResponse Currency { get; set; }
    }
}
