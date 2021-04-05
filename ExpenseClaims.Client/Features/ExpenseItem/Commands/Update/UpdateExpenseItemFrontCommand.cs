using ExpenseClaims.Client.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Features.ExpenseItem.Commands.Update
{
    public class UpdateExpenseItemFrontCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int ClaimId { get; set; }
        public int CategoryId { get; set; }
        public int CurrencyId { get; set; }
        public string Payee { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public double UsdAmount { get; set; }

        public class UpdateExpenseItemFrontCommandHandler : IRequestHandler<UpdateExpenseItemFrontCommand, int>
        {
            private readonly IExpenseItemService _itemService;

            public UpdateExpenseItemFrontCommandHandler(IExpenseItemService itemService)
            {
                _itemService = itemService;
            }

            public async Task<int> Handle(UpdateExpenseItemFrontCommand command, CancellationToken cancellationToken)
            {
                var claim = await _itemService.UpdateExpenseItem(command.Id, command);
                if (claim == null)
                {
                    throw new NullReferenceException($"Category not Found.");
                }
                else
                {
                    return claim.Data;
                }
            }
        }
    }
}
