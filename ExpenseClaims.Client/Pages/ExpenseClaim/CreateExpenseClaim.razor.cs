using ExpenseClaims.Application.Enums;
using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.Services.Constant;
using ExpenseClaims.Client.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.ExpenseClaim
{
    public partial class CreateExpenseClaim
    {
        public ExpenseClaimDetailVM Claim { get; set; }
        public List<ExpenseItemDetailVM> Items { get; set; }

        public List<ExpenseCategoryListVM> Categories { get; set; }
        public List<CurrencyListVM> Currencies { get; set; }
        public List<UserResponseVM> Approvers { get; set; } = new List<UserResponseVM>();

        public string CurrentDate = DateTime.Today.ToShortDateString();

        [Inject]
        public IExpenseClaimService ExpenseClaimService { get; set; }

        [Inject]
        public IExpenseItemService ExpenseItemService { get; set; }

        [Inject]
        public IExpenseCategoryService ExpenseCategoryService { get; set; }

        [Inject]
        public ICurrencyService CurrencyService { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        private ClaimsPrincipal AuthenticationStateProviderUser { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Claim = new ExpenseClaimDetailVM();
            Claim.SubmitDate = DateTime.Today;
            Items = new List<ExpenseItemDetailVM>();
            Categories = await ExpenseCategoryService.GetAllExpenseCategories();
            Currencies = await CurrencyService.GetAllCurrencies();
            var users = await AuthenticationService.GetUsers();
            foreach(UserResponseVM user in users)
            {
                if (user.Roles.Contains("Approver"))
                {
                    Approvers.Add(user);
                }
            }
            AuthenticationState authenticationState;

            authenticationState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            this.AuthenticationStateProviderUser = authenticationState.User;
            Claim.RequesterId = AuthenticationStateProviderUser.Claims.FirstOrDefault(c => c.Type == "uid").Value;
        }

        public async Task Create()
        {
            Claim.Status = Status.SUBMITTED;
            var response = await ExpenseClaimService.CreateExpenseClaim(Claim);
            foreach (ExpenseItemDetailVM item in Items)
            {
                item.ClaimId = response.Data;
                var itemResponse = await ExpenseItemService.CreateExpenseItem(item);
            }

            NavigationManager.NavigateTo("expenseClaimList");
        }
    }
}
