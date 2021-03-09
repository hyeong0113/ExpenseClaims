using ExpenseClaims.Application.Features.Currencies.Commands.Create;
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
    public partial class CreateCurrency
    {
        //private const int apiVersion = 1;
        public CurrencyDetailVM Currency { get; set; } = new CurrencyDetailVM();

        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Rate { get; set; }

        protected override void OnInitialized()
        {
            CurrencyDetailVM Currency = new CurrencyDetailVM();
        }

        [Inject]
        public ICurrencyService CurrencyService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async Task Create()
        {
            Currency.Code = Code;
            Currency.Name = Name;
            Currency.Symbol = Symbol;
            Currency.Rate = (double)Rate;

            //var tokenKey = await localStorage.GetItemAsync<string>("token");
            //Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);

            //await Http.PostAsJsonAsync($"api/v{apiVersion}/Currency", Currency);

            var response = await CurrencyService.CreateCurrency(Currency);

            if (response.Success)
            {
                NavigationManager.NavigateTo("currencyList");
            }
        }
    }
}
