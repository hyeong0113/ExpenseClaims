using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.ExpenseCategory
{
    public partial class CreateExpenseCategory
    {
        public ExpenseCategoryDetailVM Category { get; set; }

        protected override void OnInitialized()
        {
            Category = new ExpenseCategoryDetailVM();
        }

        [Inject]
        public IExpenseCategoryService ExpenseCategoryService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async Task Create()
        {
            var response = await ExpenseCategoryService.CreateExpenseCategory(Category);

            if (response.Success)
            {
                NavigationManager.NavigateTo("expenseCategoryList");
            }
        }
    }
}
