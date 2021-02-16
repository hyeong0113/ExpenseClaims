using ExpenseClaims.Application.Features.Currencies.Quries.GetById;
using ExpenseClaims.Application.Features.ExpenseCategories.Quries.GetById;
using ExpenseClaims.Application.Features.ExpenseItems.Queries.GetById;
using ExpenseClaims.Application.Wrappers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.ExpenseItem
{
    public partial class ExpenseItemDetail
    {
        private const int apiVersion = 1;
        private GetExpenseCategoryByIdResponse Category = null;
        private GetCurrencyByIdResponse Currency = null;

        [Parameter]
        public GetExpenseItemByIdResponse Item { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var tokenKey = await localStorage.GetItemAsync<string>("token");
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);

            var category = await Http.GetFromJsonAsync<Response<GetExpenseCategoryByIdResponse>>($"api/v{apiVersion}/ExpenseCategory/{Item.CategoryId}");
            var currency = await Http.GetFromJsonAsync<Response<GetCurrencyByIdResponse>>($"api/v{apiVersion}/Currency/{Item.CurrencyId}");

            Category = category.Data;
            Currency = currency.Data;
        }
    }
}
