using ExpenseClaims.Application.DTOs.Identity;
using ExpenseClaims.Client.Contracts;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.Identity
{
    public partial class LogIn
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAutenticated { get; set; } = false;
        public TokenRequest Token { get; set; } = new TokenRequest();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        public async Task OnSubmit()
        {
            Token.Email = UserName;
            Token.Password = Password;

            if (await AuthenticationService.Authenticate(Token.Email, Token.Password))
            {
                NavigationManager.NavigateTo("/");
                var tokenKey = await localStorage.GetItemAsync<string>("token");
            }
        }
    }
}
