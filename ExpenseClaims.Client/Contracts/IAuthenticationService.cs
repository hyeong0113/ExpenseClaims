using ExpenseClaims.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Contracts
{
    public interface IAuthenticationService
    {
        Task<bool> Authenticate(string email, string password);
        Task<bool> Register(string firstName, string lastName, string userName, string email, string password);
        Task Logout();
        Task<List<UserResponseVM>> GetUsers();
        Task<string> GetCurrentUserName();
    }
}
