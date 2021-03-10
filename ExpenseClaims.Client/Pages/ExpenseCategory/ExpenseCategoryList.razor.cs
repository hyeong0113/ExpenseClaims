using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.ExpenseCategory
{
    public partial class ExpenseCategoryList
    {
        public List<ExpenseCategoryListVM> Categories { get; set; } = null;

        [Inject]
        public IExpenseCategoryService ExpenseCategoryService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            Categories = await ExpenseCategoryService.GetAllExpenseCategories();
        }

        public async Task DeleteCategory(int categoryId)
        {
            var response = await ExpenseCategoryService.DeleteExpenseCategory(categoryId);

            if (response.Success)
            {
                NavigationManager.NavigateTo("expenseCategoryList", true);
            }
        }

        // TODO: Need to open dialog to confirm to delete
    }
}
