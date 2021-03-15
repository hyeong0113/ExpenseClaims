using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.ViewModels
{
    public class RegisterVM
    {
        [Required(AllowEmptyStrings = true)]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Email { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 6)]
        public string UserName { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = 6)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string ConfirmPassword { get; set; }
    }
}
