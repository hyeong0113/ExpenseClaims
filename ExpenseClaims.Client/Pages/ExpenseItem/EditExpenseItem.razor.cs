using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.ViewModels;
using ExpenseClaims.Client.Wrapper.ExpenseItem;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.ExpenseItem
{
    public partial class EditExpenseItem
    {
        [Parameter]
        public List<ExpenseItemWrapper> ItemWrapperList { get; set; } = new List<ExpenseItemWrapper>();

        [Parameter]
        public List<ExpenseItemDetailVM> ItemList { get; set; } = new List<ExpenseItemDetailVM>();

        [Parameter]
        public List<ExpenseCategoryListVM> Categories { get; set; } = new List<ExpenseCategoryListVM>();

        [Parameter]
        public List<CurrencyListVM> Currencies { get; set; } = new List<CurrencyListVM>();

        [Inject]
        public IExpenseItemService ExpenseItemService { get; set; }

        public ExpenseCategoryListVM Category { get; set; }
        public CurrencyListVM Currency { get; set; }

        public void AddItem()
        {
            ExpenseItemDetailVM item = new ExpenseItemDetailVM();
            ExpenseItemWrapper itemWrapper = new ExpenseItemWrapper(item, false);
            ItemWrapperList.Add(itemWrapper);
        }

        public async Task Remove(ExpenseItemWrapper itemWrapper)
        {
            ItemList.Remove(itemWrapper.Item);
            ItemWrapperList.Remove(itemWrapper);
            if (ExpenseItemService.GetExpenseItemById(itemWrapper.Item.Id) != null)
            {
                await ExpenseItemService.DeleteExpenseItem(itemWrapper.Item.Id);
            }
        }
    }
}
