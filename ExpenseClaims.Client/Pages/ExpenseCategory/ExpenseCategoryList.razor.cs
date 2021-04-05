using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.Features.ExpenseCategory.Commands.Delete;
using ExpenseClaims.Client.Features.ExpenseCategory.Queries.GetAll;
using ExpenseClaims.Client.ViewModels;
using MediatR;
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

        [Inject]
        public IMediator Mediator { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Categories = await Mediator.Send(new GetAllExpenseCategoriesFrontQuery());
        }

        public async Task DeleteCategory(int categoryId)
        {
            var response = await Mediator.Send(new DeleteExpenseCategoryFrontCommand { Id = categoryId });

            if (response)
            {
                NavigationManager.NavigateTo("expenseCategoryList", true);
            }
        }

        // TODO: Need to open dialog to confirm to delete
    }
}
