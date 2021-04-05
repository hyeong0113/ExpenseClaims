using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.Features.Currency.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Components;
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
