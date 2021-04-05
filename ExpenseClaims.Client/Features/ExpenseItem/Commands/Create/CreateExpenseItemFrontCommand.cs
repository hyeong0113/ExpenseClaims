using ExpenseClaims.Client.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Features.ExpenseItem.Commands.Create
{
    public class CreateExpenseItemFrontCommand : IRequest<int>
    {
        public int ClaimId { get; set; }
        public int CategoryId { get; set; }
        public int CurrencyId { get; set; }
        public string Payee { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public double UsdAmount { get; set; }

        public class CreateExpenseItemFrontCommandHandler : IRequestHandler<CreateExpenseItemFrontCommand, int>
        {
            private readonly IExpenseItemService _itemService;

            public CreateExpenseItemFrontCommandHandler(IExpenseItemService itemService)
            {
                _itemService = itemService;
            }

            public async Task<int> Handle(CreateExpenseItemFrontCommand command, CancellationToken cancellationToken)
            {
                var claim = await _itemService.CreateExpenseItem(command);
                return claim.Data;
            }
        }
    }
}
