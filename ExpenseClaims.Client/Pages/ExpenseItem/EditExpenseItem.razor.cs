using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.Features.ExpenseItem.Commands.Delete;
using ExpenseClaims.Client.Shared.RoundUp;
using ExpenseClaims.Client.ViewModels;
using ExpenseClaims.Client.Wrapper.ExpenseItem;
using MediatR;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        [Parameter]
        public bool IsReadonly { get; set; }

        [Parameter]
        public Claim Roles { get; set; }

        [Parameter]
        public double TotalAmount { get; set; }

        [Parameter]
        public EventCallback<double> OnTotalAmountChange { get; set; }

        [Inject]
        public IExpenseItemService ExpenseItemService { get; set; }

        [Inject]
        public IMediator Mediator { get; set; }

        public bool IsCurrencyMissing { get; set; } = true;

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
            if (itemWrapper.IsExist)
            {
                await Mediator.Send(new DeleteExpenseItemFrontCommand { Id = itemWrapper.Item.Id });
            }
            double totalAmountString = ItemList.Select(i => i.UsdAmount).Sum();
            await OnTotalAmountChange.InvokeAsync(totalAmountString);
        }

        private async Task AmountChanged(ExpenseItemWrapper itemWrapper)
        {
            var currency = Currencies.FirstOrDefault(c => c.Id == itemWrapper.Item.CurrencyId);
            if (currency != null)
            {
                itemWrapper.Item.UsdAmount = currency.Rate * itemWrapper.Item.Amount;
                double totalAmountString = ConvertToTwoDecimal.RoundUp(ItemList.Select(i => i.UsdAmount).Sum());
                await OnTotalAmountChange.InvokeAsync(totalAmountString);
            }
        }

        private async Task ActivateAmountField(ExpenseItemWrapper itemWrapper, int id)
        {
            itemWrapper.Item.CurrencyId = id;
            if (id == 0)
            {
                return;
            }
            if (itemWrapper.Item.Amount != 0)
            {
                await AmountChanged(itemWrapper);
            }
            IsCurrencyMissing = false;
        }
    }
}
