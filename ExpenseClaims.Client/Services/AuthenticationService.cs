using Blazored.LocalStorage;
using ExpenseClaims.Client.Auth;
using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Services
{
    public class AuthenticationService : BaseDataService, IAuthenticationService
    {
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationService(IBaseClient client, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage)
        {
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                TokenRequest tokenRequest = new TokenRequest() { Email = email, Password = password };
                var authenticationResponse = await _client.GetTokenAsync(tokenRequest);

                if (authenticationResponse.Data.JwToken != string.Empty)
                {
                    await _localStorage.SetItemAsync("token", authenticationResponse.Data.JwToken);
                    ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserAuthenticated(email);
                    _client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", authenticationResponse.Data.JwToken);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Register(string firstName, string lastName, string userName, string email, string password)
        {
            //RegisterRequest registrationRequest = new RegisterRequest() { FirstName = firstName, LastName = lastName, Email = email, UserName = userName, Password = password };
            //var response = await _client.RegisterAsync(registrationRequest);

            //if (!string.IsNullOrEmpty(response.UserId))
            //{
            //    return true;
            //}
            return false;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("token");
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserLoggedOut();
            _client.HttpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
