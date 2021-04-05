using ExpenseClaims.Client.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Features.ExpenseItem.Commands.Delete
{
    public class DeleteExpenseItemFrontCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public class DeleteExpenseItemFrontCommandHandler : IRequestHandler<DeleteExpenseItemFrontCommand, bool>
        {
            private readonly IExpenseItemService _itemService;

            public DeleteExpenseItemFrontCommandHandler(IExpenseItemService itemService)
            {
                _itemService = itemService;
            }

            public async Task<bool> Handle(DeleteExpenseItemFrontCommand command, CancellationToken cancellationToken)
            {
                var item = await _itemService.DeleteExpenseItem(command.Id);
                if (item == null)
                {
                    throw new NullReferenceException($"Item not Found.");
                }
                else
                {
                    return item.Success;
                }
            }
        }
    }
}
