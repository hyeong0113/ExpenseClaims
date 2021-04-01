using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.Services.Features.ExpenseCategoryService.Commands.Create;
using ExpenseClaims.Client.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Pages.ExpenseCategory
{
    public partial class CreateExpenseCategory
    {
        public CreateExpenseCategoryFrontCommand Category { get; set; }

        [Inject]
        public IExpenseCategoryService ExpenseCategoryService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IMediator Mediator { get; set; }

        protected override void OnInitialized()
        {
            Category = new CreateExpenseCategoryFrontCommand();
        }

        public async Task Create()
        {
            var response = await this.Mediator.Send(Category);

            if (response)
            {
                NavigationManager.NavigateTo("expenseCategoryList");
            }
        }
    }
}
