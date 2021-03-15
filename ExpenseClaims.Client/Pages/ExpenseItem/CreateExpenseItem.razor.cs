using ExpenseClaims.Client.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.ExpenseItem
{
    public partial class CreateExpenseItem
    {
        [Parameter]
        public List<ExpenseItemDetailVM> ItemList { get; set; } = new List<ExpenseItemDetailVM>();

        [Parameter]
        public List<ExpenseCategoryListVM> Categories { get; set; } = new List<ExpenseCategoryListVM>();

        [Parameter]
        public List<CurrencyListVM> Currencies { get; set; } = new List<CurrencyListVM>();

        public double CurrentRate { get; set; }

        private void AddItem()
        {
            ExpenseItemDetailVM wrapper = new ExpenseItemDetailVM();
            ItemList.Add(wrapper);
        }

        private void Remove(ExpenseItemDetailVM wrapper)
        {
            ItemList.Remove(wrapper);
            this.StateHasChanged();
        }
    }
}
