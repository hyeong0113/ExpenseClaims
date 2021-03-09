using ExpenseClaims.Application.Features.Currencies.Quries.GetAll;
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

namespace ExpenseClaims.Client.Pages.Currency
{
    public partial class CurrencyList
    {
        public List<CurrencyListVM> Currencies { get; set; } = null;

        [Inject]
        public ICurrencyService CurrencyService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            //var tokenKey = await localStorage.GetItemAsync<string>("token");
            //Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);

            //var response = await Http.GetFromJsonAsync<Response<IEnumerable<GetAllCurrenciesResponse>>>($"api/v{apiVersion}/Currency");
            //Currencies = response.Data;
            Currencies = await CurrencyService.GetAllCurrencies();
        }

        public async Task DeleteCategory(int currencyId)
        {
            //var tokenKey = await localStorage.GetItemAsync<string>("token");
            //Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);
            //await Http.DeleteAsync($"api/v{apiVersion}/Currency/{currencyId}");
            var response = await CurrencyService.DeleteCurrency(currencyId);

            if (response.Success)
            {
                NavigationManager.NavigateTo("currencyList", true);
            }
        }

        // TODO: Need to open dialog to confirm to delete
    }
}
