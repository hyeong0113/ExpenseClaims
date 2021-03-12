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
        public bool IsAutenticated { get; set; } = false;
        public LogInVM LogInModel { get; set; } = new LogInVM();

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async Task OnSubmit()
        {
            if (await AuthenticationService.Authenticate(LogInModel.Email, LogInModel.Password))
            {
                NavigationManager.NavigateTo("/");
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
