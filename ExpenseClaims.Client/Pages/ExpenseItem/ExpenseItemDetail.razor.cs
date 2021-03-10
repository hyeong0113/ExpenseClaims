using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.ExpenseItem
{
    public partial class ExpenseItemDetail
    {
        public ExpenseCategoryDetailVM Category { get; set; }
        public CurrencyDetailVM Currency { get; set; }

        [Parameter]
        public ExpenseItemDetailVM Item { get; set; }

        [Inject]
        public IExpenseCategoryService ExpenseCategoryService { get; set; }

        [Inject]
        public ICurrencyService CurrencyService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Category = await ExpenseCategoryService.GetExpenseCategoryById(Item.CategoryId);
            Currency = await CurrencyService.GetCurrencyById(Item.CurrencyId);
        }
    }
}
