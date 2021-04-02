using ExpenseClaims.Application.DTOs.Identity;
using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.Identity
{
    public partial class LogIn
    {
        public bool IsWrongInfo { get; set; } = false;
        public LogInVM LogInModel { get; set; } = new LogInVM();

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string ErrorMessage { get; set; }

        public async Task OnSubmit()
        {
            if (await AuthenticationService.Authenticate(LogInModel.Email, LogInModel.Password))
            {
                IsWrongInfo = false;
                ErrorMessage = null;
                NavigationManager.NavigateTo("/");
            }
            else
            {
                IsWrongInfo = true;
                ErrorMessage = "Your Id or Password is incorrect";
            }
        }

        public async Task Enter(KeyboardEventArgs e)
        {
            if (e.Code == "Enter" || e.Code == "NumpadEnter")
            {
                await OnSubmit();
            }
        }
    }
}
