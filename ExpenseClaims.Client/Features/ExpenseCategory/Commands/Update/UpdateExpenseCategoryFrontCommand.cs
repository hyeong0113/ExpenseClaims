using ExpenseClaims.Client.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Features.ExpenseCategory.Commands.Update
{
    public class UpdateExpenseCategoryFrontCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public class UpdateCurrencyFrontCommandHandler : IRequestHandler<UpdateExpenseCategoryFrontCommand, bool>
        {
            private readonly IExpenseCategoryService _categoryService;

            public UpdateCurrencyFrontCommandHandler(IExpenseCategoryService categoryService)
            {
                _categoryService = categoryService;
            }

            public async Task<bool> Handle(UpdateExpenseCategoryFrontCommand command, CancellationToken cancellationToken)
            {
                var category = await _categoryService.UpdateExpenseCategory(command.Id, command);
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
