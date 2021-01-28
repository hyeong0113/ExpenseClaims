using ExpenseClaims.Application.DTOs.Mail;
using System.Threading.Tasks;

namespace ExpenseClaims.Application.Interfaces.Shared
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}