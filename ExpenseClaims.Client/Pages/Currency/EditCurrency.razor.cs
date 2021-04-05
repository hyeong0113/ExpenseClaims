using AutoMapper;
using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.Features.Currency.Commands.Update;
using ExpenseClaims.Client.Features.Currency.Queries.GetById;
using ExpenseClaims.Client.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.Currency
{
    public partial class EditCurrency
    {
        public CurrencyDetailVM Currency { get; set; }

        [Parameter]
        public int CurrencyId { get; set; }

        [Inject]
        public ICurrencyService CurrencyService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMediator Mediator { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Currency = await Mediator.Send(new GetCurrencyByIdFrontQuery() { Id = CurrencyId });
        }

        public async Task Edit()
        {
            var mappedCurrency = Mapper.Map<UpdateCurrencyFrontCommand>(Currency);
            var response = await Mediator.Send(mappedCurrency);
            if (response)
            {
                NavigationManager.NavigateTo("currencyList", true);
            }
        }
    }
}
