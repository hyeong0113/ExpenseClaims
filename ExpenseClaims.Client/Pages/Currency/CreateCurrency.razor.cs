using ExpenseClaims.Application.Features.Currencies.Commands.Create;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.Currency
{
    public partial class CreateCurrency
    {
        private const int apiVersion = 1;
        public CreateCurrencyCommand Currency { get; set; } = new CreateCurrencyCommand();
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Rate { get; set; }


        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async Task Create()
        {
            Currency.Code = Code;
            Currency.Name = Name;
            Currency.Symbol = Symbol;
            Currency.Rate = Rate;

            var tokenKey = await localStorage.GetItemAsync<string>("token");
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);

            await Http.PostAsJsonAsync($"api/v{apiVersion}/Currency", Currency);

            NavigationManager.NavigateTo("currencyList");
        }
    }
}
