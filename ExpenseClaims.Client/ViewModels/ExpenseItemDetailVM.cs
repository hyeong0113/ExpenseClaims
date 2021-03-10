using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ExpenseClaims.Client.Services.Constant;

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

        public DateTime? Date { get; set; }

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
