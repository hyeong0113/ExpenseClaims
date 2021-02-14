using AutoMapper;
using ExpenseClaims.Application.Interfaces.Repositories;
using ExpenseClaims.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Application.Features.ExpenseItems.Queries.GetAll
{
    public class GetAllExpenseItemsQuery : IRequest<Response<IEnumerable<GetAllExpenseItemsResponse>>>
    {
        public class GetAllExpenseItemsQueryHandler : IRequestHandler<GetAllExpenseItemsQuery, Response<IEnumerable<GetAllExpenseItemsResponse>>>
        {
            private readonly IExpenseItemRepository _itemRepository;
            private readonly IMapper _mapper;

            public GetAllExpenseItemsQueryHandler(IExpenseItemRepository itemRepository, IMapper mapper)
            {
                _itemRepository = itemRepository;
                _mapper = mapper;
            }

            public async Task<Response<IEnumerable<GetAllExpenseItemsResponse>>> Handle(GetAllExpenseItemsQuery request, CancellationToken cancellationToken)
            {
                var itemList = await _itemRepository.GetListAsync();
                var itemMappedList = _mapper.Map<IEnumerable<GetAllExpenseItemsResponse>>(itemList);
                return new Response<IEnumerable<GetAllExpenseItemsResponse>>(itemMappedList);
            }
        }
    }
}
