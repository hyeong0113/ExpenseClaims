using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.Features.Currency.Commands.Delete;
using ExpenseClaims.Client.Features.Currency.Queries.GetAll;
using ExpenseClaims.Client.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
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

        [Inject]
        public IMediator Mediator { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Currencies = await Mediator.Send(new GetAllCurrenciesFrontQuery());
        }

        public async Task DeleteCategory(int currencyId)
        {
            var response = await Mediator.Send(new DeleteCurrencyFrontCommand{ Id = currencyId });

            if (response)
            {
                NavigationManager.NavigateTo("currencyList", true);
            }
        }

        // TODO: Need to open dialog to confirm to delete
    }
}
