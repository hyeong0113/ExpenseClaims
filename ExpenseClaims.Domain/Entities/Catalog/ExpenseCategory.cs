using AspNetCoreHero.Abstractions.Domain;

namespace ExpenseClaims.Domain.Entities.Catalog
{
    public class ExpenseCategory : AuditableEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}