using AspNetCoreHero.Results;
using ExpenseClaims.Application.Features.ExpenseClaims.Queries.GetAllPaged;
using ExpenseClaims.Application.Wrappers;
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
        private IEnumerable<GetAllExpenseClaimsResponse> ClaimList { get; set; } = null;
        protected override async Task OnInitializedAsync()
        {
            var tokenKey = await localStorage.GetItemAsync<string>("token");
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);
            
            var response = await Http.GetFromJsonAsync<Response<IEnumerable<GetAllExpenseClaimsResponse>>>($"api/v{apiVersion}/ExpenseClaim");
            ClaimList = response.Data;
        }
    }
}
