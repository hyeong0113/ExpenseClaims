using AspNetCoreHero.Abstractions.Domain;

namespace ExpenseClaims.Domain.Entities.Catalog
{
    public class Currency : AuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Rate { get; set; }
    }
}