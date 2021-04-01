using AspNetCoreHero.Results;
using ExpenseClaims.Application.Features.ExpenseClaims.Queries.GetAllPaged;
using ExpenseClaims.Application.Wrappers;
using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.Services.Base;
using ExpenseClaims.Client.Services.Features.ExpenseClaimService.Queries.GetAll;
using ExpenseClaims.Client.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.ExpenseClaim
{
    public partial class ExpenseClaimList
    {
        public List<ExpenseClaimListVM> ClaimList { get; set; } = null;

        [Inject]
        public IExpenseClaimService ExpenseClaimService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        private ClaimsPrincipal AuthenticationStateProviderUser { get; set; }

        [Inject]
        public IMediator Mediator { get; set; }

        public Claim Roles { get; set; } = null;

        protected override async Task OnInitializedAsync()
        {
            AuthenticationState authenticationState;

            authenticationState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            this.AuthenticationStateProviderUser = authenticationState.User;

            Roles = AuthenticationStateProviderUser.Claims.FirstOrDefault(c => c.Type == "roles");
            var userId = AuthenticationStateProviderUser.Claims.FirstOrDefault(c => c.Type == "uid").Value;

            //List<ExpenseClaimListVM> fetchedClaimList = await ExpenseClaimService.GetAllExpenseClaims(Roles, userId);

            //ClaimList = fetchedClaimList;

            ClaimList = await Mediator.Send(new GetAllExpenseClaimsFrontQuery() { Roles = Roles, UserId = userId});

        }

        public async Task DeleteClaim(int claimId)
        {
            var response = await ExpenseClaimService.DeleteExpenseClaim(claimId);

            if (response.Success)
            {
                NavigationManager.NavigateTo("expenseClaimList", true);
            }
        }
    }
}
