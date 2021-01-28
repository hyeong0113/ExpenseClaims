using System.ComponentModel.DataAnnotations;

namespace ExpenseClaims.Application.DTOs.Identity
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}