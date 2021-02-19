using AspNetCoreHero.Results;
using ExpenseClaims.Application.Features.ExpenseClaims.Queries.GetAllPaged;
using ExpenseClaims.Application.Wrappers;
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
        private const int apiVersion = 1;
        public IEnumerable<GetAllExpenseClaimsResponse> ClaimList { get; set; } = null;

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var tokenKey = await localStorage.GetItemAsync<string>("token");
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);
            
            var response = await Http.GetFromJsonAsync<Response<IEnumerable<GetAllExpenseClaimsResponse>>>($"api/v{apiVersion}/ExpenseClaim");
            ClaimList = response.Data;
        }

        public async Task DeleteClaim(int claimId)
        {
            var tokenKey = await localStorage.GetItemAsync<string>("token");
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);
            await Http.DeleteAsync($"api/v{apiVersion}/ExpenseClaim/{claimId}");
            NavigationManager.NavigateTo("expenseClaimList", true);
        }
    }
}
