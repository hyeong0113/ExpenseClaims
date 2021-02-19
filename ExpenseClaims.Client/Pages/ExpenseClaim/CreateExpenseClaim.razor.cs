using ExpenseClaims.Application.Features.Currencies.Quries.GetAll;
using ExpenseClaims.Application.Features.ExpenseCategories.Quries.GetAll;
using ExpenseClaims.Application.Features.ExpenseClaims.Commands.Create;
using ExpenseClaims.Application.Features.ExpenseItems.Commands.Create;
using ExpenseClaims.Application.Wrappers;
using ExpenseClaims.Client.Shared.Wrapper;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.ExpenseClaim
{
    public partial class CreateExpenseClaim
    {
        private const int apiVersion = 1;
        public CreateExpenseClaimCommand Claim { get; set; } = new CreateExpenseClaimCommand();
        public List<CreateExpenseItemCommand> Items { get; set; } = new List<CreateExpenseItemCommand>();
        public List<CreateExpenseItemWrapper> ItemWrappers { get; set; } = new List<CreateExpenseItemWrapper>();

        public string Title { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public DateTime ProcessedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string RequesterComments { get; set; }
        public string ApproverComments { get; set; }
        public string FinanceComments { get; set; }

        public IEnumerable<GetAllExpenseCategoriesResponse> Categories { get; set; } = new List<GetAllExpenseCategoriesResponse>();
        public IEnumerable<GetAllCurrenciesResponse> Currencies { get; set; } = new List<GetAllCurrenciesResponse>();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var tokenKey = await localStorage.GetItemAsync<string>("token");
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);

            var category = await Http.GetFromJsonAsync<Response<IEnumerable<GetAllExpenseCategoriesResponse>>>($"api/v{apiVersion}/ExpenseCategory");
            Categories = category.Data;

            var currency = await Http.GetFromJsonAsync<Response<IEnumerable<GetAllCurrenciesResponse>>>($"api/v{apiVersion}/Currency");
            Currencies = currency.Data;
        }

        public async Task Create()
        {
            Claim.Title = Title;
            Claim.SubmitDate = SubmitDate;
            Claim.ApprovalDate = ApprovalDate;
            Claim.ProcessedDate = ProcessedDate;
            Claim.TotalAmount = TotalAmount;
            Claim.Status = Status;
            Claim.RequesterComments = RequesterComments;
            Claim.ApproverComments = ApproverComments;
            Claim.FinanceComments = FinanceComments;

            var tokenKey = await localStorage.GetItemAsync<string>("token");
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);
            var createdClaimResponse = await Http.PostAsJsonAsync($"api/v{apiVersion}/ExpenseClaim", Claim);

            var createdClaimResponseJson = JObject.Parse(createdClaimResponse.Content.ReadAsStringAsync().Result);
            string claimIdString = createdClaimResponseJson["data"].ToString();
            int claimId = Int32.Parse(claimIdString);

            foreach (CreateExpenseItemWrapper wrapper in ItemWrappers)
            {
                CreateExpenseItemCommand tempItem = new CreateExpenseItemCommand();
                tempItem.ClaimId = claimId;
                tempItem.CategoryId = wrapper.Category.Id;
                tempItem.CurrencyId = wrapper.Currency.Id;
                tempItem.Payee = wrapper.Payee;
                tempItem.Date = wrapper.Date;
                tempItem.Description = wrapper.Description;
                tempItem.Amount = wrapper.Amount;
                tempItem.USDAmount = wrapper.USDAmount;
                Items.Add(tempItem);
            }

            foreach (CreateExpenseItemCommand item in Items)
            {
                await Http.PostAsJsonAsync($"api/v{apiVersion}/ExpenseItem", item);
            }

            NavigationManager.NavigateTo("expenseClaimList");
        }

        private void AddItem()
        {
            CreateExpenseItemWrapper wrapper = new CreateExpenseItemWrapper();
            ItemWrappers.Add(wrapper);
        }

        private void Remove(CreateExpenseItemWrapper wrapper)
        {
            ItemWrappers.Remove(wrapper);
        }
    }
}
