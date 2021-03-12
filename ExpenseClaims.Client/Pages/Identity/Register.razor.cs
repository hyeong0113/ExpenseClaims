using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.Identity
{
    public partial class Register
    {
        public RegisterVM RegisterModel { get; set; } = new RegisterVM();

        [Inject]
        public IAuthenticationService AuthenticationService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }


        public async Task OnSubmit()
        {
            if (await AuthenticationService.Register(RegisterModel.FirstName, RegisterModel.LastName
                , RegisterModel.UserName, RegisterModel.Email, RegisterModel.Password))
            {
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
