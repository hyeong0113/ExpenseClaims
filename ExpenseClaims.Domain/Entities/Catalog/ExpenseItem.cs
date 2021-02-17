using AspNetCoreHero.Abstractions.Domain;
using System;

namespace ExpenseClaims.Domain.Entities.Catalog
{
    public class ExpenseItem : AuditableEntity
    {
        public int ClaimId { get; set; }
        public int CategoryId { get; set; }
        public int CurrencyId { get; set; }
        public string Payee { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal USDAmount { get; set; }

        public virtual ExpenseClaim Claim { get; set; }
        public virtual ExpenseCategory Category { get; set; }
        public virtual Currency Currency { get; set; }
    }
}