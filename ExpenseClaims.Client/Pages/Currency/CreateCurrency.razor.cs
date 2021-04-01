using ExpenseClaims.Application.Features.Currencies.Commands.Create;
using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.Services.Features.CurrencyService.Commands.Create;
using ExpenseClaims.Client.ViewModels;
using MediatR;
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
        public CreateCurrencyFrontCommand Currency { get; set; }

        [Inject]
        public ICurrencyService CurrencyService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMediator Mediator { get; set; }

        protected override void OnInitialized()
        {
            Currency = new CreateCurrencyFrontCommand();
        }

        public async Task Create()
        {
            var response = await this.Mediator.Send(Currency);

            if (response)
            {
                NavigationManager.NavigateTo("currencyList");
            }
        }
    }
}
