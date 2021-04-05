using ExpenseClaims.Client.Features.ExpenseItem.Commands.Create;
using ExpenseClaims.Client.Shared.RoundUp;
using ExpenseClaims.Client.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseClaims.Client.Pages.ExpenseItem
{
    public partial class CreateExpenseItem
    {
        [Parameter]
        public List<CreateExpenseItemFrontCommand> ItemList { get; set; } = new List<CreateExpenseItemFrontCommand>();

        [Parameter]
        public List<ExpenseCategoryListVM> Categories { get; set; } = new List<ExpenseCategoryListVM>();

        [Parameter]
        public List<CurrencyListVM> Currencies { get; set; } = new List<CurrencyListVM>();
        
        [Parameter]
        public double TotalAmount { get; set; }

        [Parameter]
        public EventCallback<double> OnTotalAmountChange { get; set; }

        public bool IsCurrencyMissing { get; set; } = true;

        private void AddItem()
        {
            CreateExpenseItemFrontCommand wrapper = new CreateExpenseItemFrontCommand();
            ItemList.Add(wrapper);
        }

        private void Remove(CreateExpenseItemFrontCommand wrapper)
        {
            ItemList.Remove(wrapper);
            double totalAmountString = ItemList.Select(i => i.UsdAmount).Sum();
            OnTotalAmountChange.InvokeAsync(totalAmountString);
        }

        private void AmountChanged(CreateExpenseItemFrontCommand item)
        {
            var currency = Currencies.FirstOrDefault(c => c.Id == item.CurrencyId);
            if (currency != null)
            {
                item.UsdAmount = currency.Rate * item.Amount;
                double totalAmountString = ConvertToTwoDecimal.RoundUp(ItemList.Select(i => i.UsdAmount).Sum());
                OnTotalAmountChange.InvokeAsync(totalAmountString);
            }
        }

        private void ActivateAmountField(CreateExpenseItemFrontCommand item, int id)
        {
            item.CurrencyId = id;

            if (id == 0)
            {
                return;
            }

            if (item.Amount != 0)
            {
                AmountChanged(item);
            }

            IsCurrencyMissing = false;
        }
    }
}
