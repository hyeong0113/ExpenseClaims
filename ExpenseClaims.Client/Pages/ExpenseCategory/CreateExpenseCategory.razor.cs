using ExpenseClaims.Application.Features.ExpenseCategories.Commands.Create;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.ExpenseCategory
{
    public partial class CreateExpenseCategory
    {
        private const int apiVersion = 1;
        public CreateExpenseCategoryCommand Category { get; set; } = new CreateExpenseCategoryCommand();    
        public string Name { get; set; }
        public string Code { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async Task Create()
        {
            Category.Name = Name;
            Category.Code = Code;

            var tokenKey = await localStorage.GetItemAsync<string>("token");
            Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenKey);

            await Http.PostAsJsonAsync($"api/v{apiVersion}/ExpenseCategory", Category);

            NavigationManager.NavigateTo("expenseCategoryList");
        }
    }
}
