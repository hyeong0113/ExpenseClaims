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
        public CurrencyDetailVM Currency { get; set; }

        protected override void OnInitialized()
        {
            Currency = new CurrencyDetailVM();
        }

        [Inject]
        public ICurrencyService CurrencyService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async Task Create()
        {
            var response = await CurrencyService.CreateCurrency(Currency);

            if (response.Success)
            {
                NavigationManager.NavigateTo("currencyList");
            }
        }
    }
}
