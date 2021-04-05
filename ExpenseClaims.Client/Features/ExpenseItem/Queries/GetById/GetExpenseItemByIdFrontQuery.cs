using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Features.ExpenseItem.Queries.GetById
{
    public class GetExpenseItemByIdFrontQuery : IRequest<ExpenseItemDetailVM>
    {
        public int Id { get; set; }

        public class GetExpenseItemByIdFrontQueryHandler : IRequestHandler<GetExpenseItemByIdFrontQuery, ExpenseItemDetailVM>
        {
            private readonly IExpenseItemService _itemService;

            public GetExpenseItemByIdFrontQueryHandler(IExpenseItemService itemService)
            {
                _itemService = itemService;
            }

            public async Task<ExpenseItemDetailVM> Handle(GetExpenseItemByIdFrontQuery query, CancellationToken cancellationToken)
            {
                var item = await _itemService.GetExpenseItemById(query.Id);
                if (item == null)
                {
                    throw new NullReferenceException($"Item not Found.");
                }
                else
                {
                    return item;
                }
            }
        }
    }
}
