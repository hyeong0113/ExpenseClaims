using ExpenseClaims.Client.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Features.ExpenseCategory.Commands.Delete
{
    public class DeleteExpenseCategoryFrontCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public class DeleteExpenseCategoryFrontCommandHandler : IRequestHandler<DeleteExpenseCategoryFrontCommand, bool>
        {
            private readonly IExpenseCategoryService _categoryService;

            public DeleteExpenseCategoryFrontCommandHandler(IExpenseCategoryService categoryService)
            {
                _categoryService = categoryService;
            }

            public async Task<bool> Handle(DeleteExpenseCategoryFrontCommand command, CancellationToken cancellationToken)
            {
                var category = await _categoryService.DeleteExpenseCategory(command.Id);
                if (category == null)
                {
                    throw new NullReferenceException($"Category not Found.");
                }
                else
                {
                    return category.Success;
                }
            }
        }
    }
}
