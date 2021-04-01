using ExpenseClaims.Application.Features.ExpenseClaims.Queries.GetById;
using ExpenseClaims.Application.Wrappers;
using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.Services.Features.ExpenseClaimService.Queries.GetById;
using ExpenseClaims.Client.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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
