using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.ViewModels
{
    public class CurrencyDetailVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "Currency code should be 10 characters or less")]
        public string Code { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The name of the category should be 50 characters or less")]
        public string Name { get; set; }

        [Required]
        public string Symbol { get; set; }

        [Required]
        public double Rate { get; set; }
    }
}
