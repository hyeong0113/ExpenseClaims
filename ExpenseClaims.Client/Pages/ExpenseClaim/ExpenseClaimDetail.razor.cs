using ExpenseClaims.Application.Features.ExpenseClaims.Queries.GetById;
using ExpenseClaims.Application.Wrappers;
using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.ViewModels;
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
        public List<UserResponseVM> Users { get; set; } = new List<UserResponseVM>();

        [Inject]
        private IAuthenticationService AuthenticationService { get; set; }

        [Inject]
        public IExpenseClaimService ExpenseClaimService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Claim = await ExpenseClaimService.GetExpenseClaimById(ClaimId);
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
