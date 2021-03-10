using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.ExpenseClaim
{
    public partial class CreateExpenseClaim
    {
        public ExpenseClaimDetailVM Claim { get; set; }
        public List<ExpenseItemDetailVM> Items { get; set; }

        public List<ExpenseCategoryListVM> Categories { get; set; }
        public List<CurrencyListVM> Currencies { get; set; }

        [Inject]
        public IExpenseClaimService ExpenseClaimService { get; set; }

        [Inject]
        public IExpenseItemService ExpenseItemService { get; set; }

        [Inject]
        public IExpenseCategoryService ExpenseCategoryService { get; set; }

        [Inject]
        public ICurrencyService CurrencyService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Claim = new ExpenseClaimDetailVM();
            Items = new List<ExpenseItemDetailVM>();
            Categories = await ExpenseCategoryService.GetAllExpenseCategories();
            Currencies = await CurrencyService.GetAllCurrencies();
        }

        public async Task Create()
        {
            var response = await ExpenseClaimService.CreateExpenseClaim(Claim);

            foreach (ExpenseItemDetailVM item in Items)
            {
                item.ClaimId = response.Data;
                var itemResponse = await ExpenseItemService.CreateExpenseItem(item);
            }

            NavigationManager.NavigateTo("expenseClaimList");
        }
    }
}
