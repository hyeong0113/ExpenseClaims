using ExpenseClaims.Application.Features.Currencies.Quries.GetById;
using ExpenseClaims.Application.Wrappers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.Currency
{
    public partial class EditCurrency
    {
        private const int apiVersion = 1;
        public GetCurrencyByIdResponse Currency { get; set; } = null;

        [Parameter]
        public int CurrencyId { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var tokenKey = await localStorage.GetItemAsync<string>("token");
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);

            CurrencyId = CurrencyId;
            var response = await Http.GetFromJsonAsync<Response<GetCurrencyByIdResponse>>($"api/v{apiVersion}/Currency/{CurrencyId}");

            Currency = response.Data;
        }

        public async Task Edit()
        {
            var tokenKey = await localStorage.GetItemAsync<string>("token");
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);

            await Http.PutAsJsonAsync($"api/v{apiVersion}/Currency/{Currency.Id}", Currency);

            NavigationManager.NavigateTo("currencyList");
        }
    }
}
