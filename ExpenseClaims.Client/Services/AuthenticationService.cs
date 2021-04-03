using AutoMapper;
using Blazored.LocalStorage;
using ExpenseClaims.Client.Auth;
using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.Services.Base;
using ExpenseClaims.Client.ViewModels;
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
        private readonly IMapper _mapper;

        public AuthenticationService(IBaseClient client, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider, IMapper mapper) : base(client, localStorage)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _mapper = mapper;
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
                    await _localStorage.SetItemAsync("userName", authenticationResponse.Data.UserName);

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
            RegisterRequest registrationRequest = new RegisterRequest() { FirstName = firstName, LastName = lastName, Email = email, UserName = userName, Password = password, ConfirmPassword = password };
            
            var response = await _client.RegisterAsync(registrationRequest);

            if (!string.IsNullOrEmpty(response.Data))
            {
                return true;
            }
            return false;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("token");
            ((CustomAuthenticationStateProvider)_authenticationStateProvider).SetUserLoggedOut();
            _client.HttpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<List<UserResponseVM>> GetUsers()
        {
            var users = await _client.GetUsersAsync();
            var mappedUsers = _mapper.Map<List<UserResponseVM>>(users.Data);
            return mappedUsers;
        }

        public async Task<string> GetCurrentUserName()
        {
            return await _localStorage.GetItemAsync<string>("userName");
        }
    }
}
