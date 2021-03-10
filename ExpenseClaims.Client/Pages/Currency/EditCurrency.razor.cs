using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.ViewModels;
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

        protected override async Task OnInitializedAsync()
        {
            Currency = await CurrencyService.GetCurrencyById(CurrencyId);
        }

        public async Task Edit()
        {
            var response = await CurrencyService.UpdateCurrency(CurrencyId, Currency);

            if (response.Success)
            {
                NavigationManager.NavigateTo("currencyList", true);
            }
        }
    }
}
