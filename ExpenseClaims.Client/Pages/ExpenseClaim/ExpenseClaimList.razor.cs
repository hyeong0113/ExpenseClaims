using AspNetCoreHero.Results;
using ExpenseClaims.Application.Features.ExpenseClaims.Queries.GetAllPaged;
using ExpenseClaims.Application.Wrappers;
using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.Services.Base;
using ExpenseClaims.Client.ViewModels;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;
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
        protected override async Task OnInitializedAsync()
        {
            ClaimList = await ExpenseClaimService.GetAllExpenseClaims();
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
