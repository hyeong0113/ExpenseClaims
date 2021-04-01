using AutoMapper;
using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.Services.Constant;
using ExpenseClaims.Client.Services.Features.ExpenseClaimService.Commands.Update;
using ExpenseClaims.Client.ViewModels;
using ExpenseClaims.Client.Wrapper.ExpenseItem;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        public string CurrentStatus { get; set; }

        public Claim Roles { get; set; } = null;
        public bool IsReadonly { get; set; } = false;

        [Inject]
        AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        private ClaimsPrincipal AuthenticationStateProviderUser { get; set; }

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

        [Inject]
        public IMediator Mediator { get; set; }

        [Inject]
        IMapper Mapper { get; set; }

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

            AuthenticationState authenticationState;

            authenticationState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            this.AuthenticationStateProviderUser = authenticationState.User;

            Roles = AuthenticationStateProviderUser.Claims.FirstOrDefault(c => c.Type == "roles");

            if (Roles.Value.Contains("Manager"))
            {
                IsReadonly = true;
            }
        }

        public async Task Edit()
        {
            if (Claim.Status == Status.QUERIED)
            {
                Claim.Status = Status.RESUBMITTED;
            }
            else
            {
                Claim.Status = CurrentStatus;
            }

            if (Roles.Value.Contains("Approver"))
            {
                Claim.ApprovalDate = DateTime.Today;
            }

            if (Roles.Value.Contains("Financer"))
            {
                Claim.ProcessedDate = DateTime.Today;
            }

            var mappedClaim = Mapper.Map<UpdateExpenseClaimFrontCommand>(Claim);
            var claimId = await Mediator.Send(mappedClaim);

            foreach (ExpenseItemWrapper itemWrapper in ItemWrappers)
            {
                if (!itemWrapper.IsExist)
                {
                    itemWrapper.Item.ClaimId = claimId;
                    var created = await ExpenseItemService.CreateExpenseItem(itemWrapper.Item);
                }
                else
                {
                    var updated = await ExpenseItemService.UpdateExpenseItem(itemWrapper.Item.Id, itemWrapper.Item);
                }
            }

            NavigationManager.NavigateTo("expenseClaimList");
        }

        void TotalAmountChangeHandler(double totalAmount)
        {
            Claim.TotalAmount = totalAmount;
        }
    }
}
