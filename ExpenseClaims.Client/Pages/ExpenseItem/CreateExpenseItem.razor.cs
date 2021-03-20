using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        
        [Parameter]
        public double TotalAmount { get; set; }

        [Parameter]
        public EventCallback<double> OnTotalAmountChange { get; set; }

        public bool IsCurrencyMissing { get; set; } = true;

        private void AddItem()
        {
            ExpenseItemDetailVM wrapper = new ExpenseItemDetailVM();
            ItemList.Add(wrapper);
        }

        private void Remove(ExpenseItemDetailVM wrapper)
        {
            ItemList.Remove(wrapper);
            double totalAmountString = ItemList.Select(i => i.UsdAmount).Sum();
            OnTotalAmountChange.InvokeAsync(totalAmountString);
        }

        private void AmountChanged(ExpenseItemDetailVM item)
        {
            var currency = Currencies.FirstOrDefault(c => c.Id == item.CurrencyId);
            if (currency != null)
            {
                item.UsdAmount = currency.Rate * item.Amount;
                double totalAmountString = ItemList.Select(i => i.UsdAmount).Sum();
                OnTotalAmountChange.InvokeAsync(totalAmountString);
            }
        }

        private void ActivateAmountField(int id)
        {
            Console.WriteLine(id);

            if (id == 0)
            {
                return;
            }
            IsCurrencyMissing = false;
            Console.WriteLine(IsCurrencyMissing);
        }
    }
}
