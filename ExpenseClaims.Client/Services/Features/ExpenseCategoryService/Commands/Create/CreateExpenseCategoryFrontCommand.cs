using ExpenseClaims.Client.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Services.Features.ExpenseCategoryService.Commands.Create
{
    public class CreateExpenseCategoryFrontCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public class CreateExpenseCategoryFrontCommandHandler : IRequestHandler<CreateExpenseCategoryFrontCommand, bool>
        {
            private readonly IExpenseCategoryService _categoryService;

            public CreateExpenseCategoryFrontCommandHandler(IExpenseCategoryService categoryService)
            {
                _categoryService = categoryService;
            }

            public async Task<bool> Handle(CreateExpenseCategoryFrontCommand command, CancellationToken cancellationToken)
            {
                var category = await _categoryService.CreateExpenseCategory(command);
                return category.Success;
            }
        }
    }
}
