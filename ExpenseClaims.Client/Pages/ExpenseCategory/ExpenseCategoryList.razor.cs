using ExpenseClaims.Application.Features.ExpenseCategories.Quries.GetAll;
using ExpenseClaims.Application.Wrappers;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.ExpenseCategory
{
    public partial class ExpenseCategoryList
    {
        private const int apiVersion = 1;
        public IEnumerable<GetAllExpenseCategoriesResponse> Categories { get; set; } = null;

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            var tokenKey = await localStorage.GetItemAsync<string>("token");
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);

            var response = await Http.GetFromJsonAsync<Response<IEnumerable<GetAllExpenseCategoriesResponse>>>($"api/v{apiVersion}/ExpenseCategory");
            Categories = response.Data;
        }

        public async Task DeleteCategory(int categoryId)
        {
            var tokenKey = await localStorage.GetItemAsync<string>("token");
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);
            await Http.DeleteAsync($"api/v{apiVersion}/ExpenseCategory/{categoryId}");
            NavigationManager.NavigateTo("expenseCategoryList", true);
        }

        // TODO: Need to open dialog to confirm to delete
    }
}
