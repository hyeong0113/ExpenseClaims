using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.Features.ExpenseClaim.Commands.Delete;
using ExpenseClaims.Client.Features.ExpenseClaim.Queries.GetAll;
using ExpenseClaims.Client.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Linq;
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

            ClaimList = await Mediator.Send(new GetAllExpenseClaimsFrontQuery() { Roles = Roles, UserId = userId});
        }

        public async Task DeleteClaim(int claimId)
        {
            var response = await Mediator.Send(new DeleteExpenseClaimFrontCommand { Id = claimId });

            if (response)
            {
                NavigationManager.NavigateTo("expenseClaimList", true);
            }
        }
    }
}
