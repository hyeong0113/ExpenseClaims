using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Services.Features.ExpenseItemService.Queries.GetAll
{
    public class GetAllExpenseItemsFrontQuery : IRequest<List<ExpenseItemListVM>>
    {
        public class GetAllExpenseItemsFrontQueryHandler : IRequestHandler<GetAllExpenseItemsFrontQuery, List<ExpenseItemListVM>>
        {
            private readonly IExpenseItemService _itemService;

            public GetAllExpenseItemsFrontQueryHandler(IExpenseItemService itemService)
            {
                _itemService = itemService;
            }

            public async Task<List<ExpenseItemListVM>> Handle(GetAllExpenseItemsFrontQuery query, CancellationToken cancellationToken)
            {
                var items = await _itemService.GetAllExpenseItems();
                return items;
            }
        }
    }
}
