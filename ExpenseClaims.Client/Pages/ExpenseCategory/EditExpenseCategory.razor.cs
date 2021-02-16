using ExpenseClaims.Application.Features.ExpenseCategories.Quries.GetById;
using ExpenseClaims.Application.Wrappers;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.ExpenseCategory
{
    public partial class EditExpenseCategory
    {
        private const int apiVersion = 1;
        public GetExpenseCategoryByIdResponse Category { get; set; } = null;

        [Parameter]
        public int CategoryId { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var tokenKey = await localStorage.GetItemAsync<string>("token");
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);

            CategoryId = CategoryId;
            var response = await Http.GetFromJsonAsync<Response<GetExpenseCategoryByIdResponse>>($"api/v{apiVersion}/ExpenseCategory/{CategoryId}");

            Category = response.Data;
        }

        public async Task EditCategory()
        {
            var tokenKey = await localStorage.GetItemAsync<string>("token");
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);

            await Http.PutAsJsonAsync($"api/v{apiVersion}/ExpenseCategory/{Category.Id}", Category);

            NavigationManager.NavigateTo("expenseCategoryList");
        }
    }
}
