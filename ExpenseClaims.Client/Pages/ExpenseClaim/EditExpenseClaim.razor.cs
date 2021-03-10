using ExpenseClaims.Application.Features.Currencies.Quries.GetAll;
using ExpenseClaims.Application.Features.ExpenseCategories.Quries.GetAll;
using ExpenseClaims.Application.Features.ExpenseClaims.Queries.GetById;
using ExpenseClaims.Application.Features.ExpenseItems.Commands.Update;
using ExpenseClaims.Application.Features.ExpenseItems.Queries.GetById;
using ExpenseClaims.Application.Wrappers;
using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.Services.Constant;
using ExpenseClaims.Client.ViewModels;
using ExpenseClaims.Client.Wrapper.ExpenseItem;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.ExpenseClaim
{
    public partial class EditExpenseClaim
    {
        public ExpenseClaimDetailVM Claim { get; set; }
        public List<ExpenseItemDetailVM> Items { get; set; }

        public List<ExpenseItemWrapper> ItemWrappers { get; set; } = new List<ExpenseItemWrapper>();

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

        [Parameter]
        public int ClaimId { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Claim = await ExpenseClaimService.GetExpenseClaimById(ClaimId);
            Items = Claim.Items.ToList();
            Categories = await ExpenseCategoryService.GetAllExpenseCategories();
            Currencies = await CurrencyService.GetAllCurrencies();

            foreach (ExpenseItemDetailVM item in Items)
            {
                ItemWrappers.Add(new ExpenseItemWrapper(item, true));
            }
        }

        public async Task Edit()
        {
            var claimUpdated = await ExpenseClaimService.UpdateExpenseClaim(Claim.Id, Claim);
            foreach (ExpenseItemWrapper itemWrapper in ItemWrappers)
            {
                if (!itemWrapper.IsExist)
                {
                    itemWrapper.Item.ClaimId = claimUpdated.Data;
                    var created = await ExpenseItemService.CreateExpenseItem(itemWrapper.Item);
                }
                else
                {
                    var updated = await ExpenseItemService.UpdateExpenseItem(itemWrapper.Item.Id, itemWrapper.Item);
                }
            }

            NavigationManager.NavigateTo("expenseClaimList");
        }
    }
}
