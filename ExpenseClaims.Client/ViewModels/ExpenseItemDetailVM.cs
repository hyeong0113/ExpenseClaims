using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExpenseClaims.Client.ViewModels
{
    public class ExpenseItemDetailVM
    {
        public int Id { get; set; }

        [Required]
        public int ClaimId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int CurrencyId { get; set; }

        [Required]
        public string Payee { get; set; }

        [Required]
        public System.DateTimeOffset Date { get; set; }

        [StringLength(100, ErrorMessage = "The comment should be 100 characters or less")]
        public string Description { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public double UsdAmount { get; set; }

        public ExpenseCategoryDetailVM Category { get; set; }

        public CurrencyDetailVM Currency { get; set; }
    }
}
