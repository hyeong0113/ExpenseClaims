using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.Features.ExpenseClaim.Queries.GetById;
using ExpenseClaims.Client.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.ExpenseClaim
{
    public partial class ExpenseClaimDetail
    {
        public ExpenseClaimDetailVM Claim { get; set; }

        [Parameter]
        public int ClaimId { get; set; }

        public string RequesterName { get; set; }

        public string ApproverName { get; set; }

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        [Inject]
        public IExpenseClaimService ExpenseClaimService { get; set; }

        [Inject]
        public IMediator Mediator { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Claim = await Mediator.Send(new GetExpenseClaimByIdFrontQuery() { Id = ClaimId });

            var users = await AuthenticationService.GetUsers();

            foreach (UserResponseVM user in users)
            {
                if (user.Id == Claim.RequesterId)
                {
                    RequesterName = user.UserName;
                }
                if (user.Id == Claim.ApproverId)
                {
                    ApproverName = user.UserName;
                }
            }
        }
    }
}
