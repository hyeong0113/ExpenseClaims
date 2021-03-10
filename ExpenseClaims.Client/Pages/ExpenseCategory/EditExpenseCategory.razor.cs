using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.ExpenseCategory
{
    public partial class EditExpenseCategory
    {
        public ExpenseCategoryDetailVM Category { get; set; }

        [Parameter]
        public int CategoryId { get; set; }

        [Inject]
        public IExpenseCategoryService ExpenseCategoryService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Category = await ExpenseCategoryService.GetExpenseCategoryById(CategoryId);
        }

        public async Task Edit()
        {
            var response = await ExpenseCategoryService.UpdateExpenseCategory(CategoryId, Category);

            if (response.Success)
            {
                NavigationManager.NavigateTo("expenseCategoryList", true);
            }
        }
    }
}
