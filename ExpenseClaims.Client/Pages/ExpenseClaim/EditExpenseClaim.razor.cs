using ExpenseClaims.Application.Features.Currencies.Quries.GetAll;
using ExpenseClaims.Application.Features.ExpenseCategories.Quries.GetAll;
using ExpenseClaims.Application.Features.ExpenseClaims.Queries.GetById;
using ExpenseClaims.Application.Features.ExpenseItems.Commands.Update;
using ExpenseClaims.Application.Features.ExpenseItems.Queries.GetById;
using ExpenseClaims.Application.Wrappers;
using ExpenseClaims.Client.Shared.Wrapper;
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
        private const int apiVersion = 1;
        public GetExpenseClaimByIdResponse Claim { get; set; } = null;
        public List<UpdateExpenseItemWrapper> ItemWrappers { get; set; } = new List<UpdateExpenseItemWrapper>();
        public List<UpdateExpenseItemCommand> Items { get; set; } = new List<UpdateExpenseItemCommand>();

        [Parameter]
        public int ClaimId { get; set; }

        public IEnumerable<GetAllExpenseCategoriesResponse> Categories { get; set; } = new List<GetAllExpenseCategoriesResponse>();
        public IEnumerable<GetAllCurrenciesResponse> Currencies { get; set; } = new List<GetAllCurrenciesResponse>();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var tokenKey = await localStorage.GetItemAsync<string>("token");
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);

            ClaimId = ClaimId;
            var response = await Http.GetFromJsonAsync<Response<GetExpenseClaimByIdResponse>>($"api/v{apiVersion}/ExpenseClaim/{ClaimId}");
            Claim = response.Data;

            var category = await Http.GetFromJsonAsync<Response<IEnumerable<GetAllExpenseCategoriesResponse>>>($"api/v{apiVersion}/ExpenseCategory");
            Categories = category.Data;

            var currency = await Http.GetFromJsonAsync<Response<IEnumerable<GetAllCurrenciesResponse>>>($"api/v{apiVersion}/Currency");
            Currencies = currency.Data;

            foreach (GetExpenseItemByIdResponse item in Claim.Items)
            {
                UpdateExpenseItemWrapper tempItem = new UpdateExpenseItemWrapper();
                tempItem.Id = item.Id;
                tempItem.ClaimId = item.ClaimId;
                tempItem.Category = Categories.FirstOrDefault(cat => cat.Id == item.CategoryId);
                tempItem.Currency = Currencies.FirstOrDefault(cur => cur.Id == item.CurrencyId);
                tempItem.Payee = item.Payee;
                tempItem.Date = item.Date;
                tempItem.Description = item.Description;
                tempItem.Amount = item.Amount;
                tempItem.USDAmount = item.USDAmount;

                ItemWrappers.Add(tempItem);
            }
        }

        public async Task Edit()
        {
            var tokenKey = await localStorage.GetItemAsync<string>("token");
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);
            var createdClaimResponse = await Http.PutAsJsonAsync($"api/v{apiVersion}/ExpenseClaim/{Claim.Id}", Claim);

            foreach (UpdateExpenseItemWrapper wrapper in ItemWrappers)
            {
                GetExpenseItemByIdResponse item = Claim.Items.FirstOrDefault(i => i.Id == wrapper.Id);
                item.CategoryId = wrapper.Category.Id;
                item.CurrencyId = wrapper.Currency.Id;
                item.Payee = wrapper.Payee;
                item.Date = wrapper.Date;
                item.Description = wrapper.Description;
                item.Amount = wrapper.Amount;
                item.USDAmount = wrapper.USDAmount;
            }

            foreach (UpdateExpenseItemCommand item in Items)
            {
                await Http.PutAsJsonAsync($"api/v{apiVersion}/ExpenseItem/{item.Id}", item);
            }

            NavigationManager.NavigateTo("expenseClaimList");
        }

        //private void AddItem()
        //{
        //    CreateExpenseItemWrapper wrapper = new CreateExpenseItemWrapper();
        //    //ItemWrappers.Add(wrapper);
        //}
    }
}
