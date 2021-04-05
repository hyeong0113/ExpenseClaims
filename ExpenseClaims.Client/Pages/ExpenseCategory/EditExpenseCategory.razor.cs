using AutoMapper;
using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.Features.ExpenseCategory.Commands.Update;
using ExpenseClaims.Client.Features.ExpenseCategory.Queries.GetById;
using ExpenseClaims.Client.ViewModels;
using MediatR;
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

        [Inject]
        public IMediator Mediator { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Category = await Mediator.Send(new GetExpenseCategoryByIdFrontQuery() { Id = CategoryId });
        }

        public async Task Edit()
        {
            var mappedCategory = Mapper.Map<UpdateExpenseCategoryFrontCommand>(Category);
            var response = await Mediator.Send(mappedCategory);
            if (response)
            {
                NavigationManager.NavigateTo("expenseCategoryList", true);
            }
        }
    }
}
