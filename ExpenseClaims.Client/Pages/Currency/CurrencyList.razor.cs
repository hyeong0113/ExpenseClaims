using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.ViewModels;
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
        protected override async Task OnInitializedAsync()
        {
            Currencies = await CurrencyService.GetAllCurrencies();
        }

        public async Task DeleteCategory(int currencyId)
        {
            var response = await CurrencyService.DeleteCurrency(currencyId);

            if (response.Success)
            {
                NavigationManager.NavigateTo("currencyList", true);
            }
        }

        // TODO: Need to open dialog to confirm to delete
    }
}
