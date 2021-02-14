using AutoMapper;
using ExpenseClaims.Application.Exceptions;
using ExpenseClaims.Application.Interfaces.Repositories;
using ExpenseClaims.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Application.Features.ExpenseItems.Queries.GetById
{
    public class GetExpenseItemByIdQuery : IRequest<Response<GetExpenseItemByIdResponse>>
    {
        public int Id { get; set; }

        public class GetExpenseitemByIdQueryHandler : IRequestHandler<GetExpenseItemByIdQuery, Response<GetExpenseItemByIdResponse>>
        {
            private readonly IExpenseItemRepository _itemRepository;
            private readonly IMapper _mapper;

            public GetExpenseitemByIdQueryHandler(IExpenseItemRepository itemRepository, IMapper mapper)
            {
                _itemRepository = itemRepository;
                _mapper = mapper;
            }

            public async Task<Response<GetExpenseItemByIdResponse>> Handle(GetExpenseItemByIdQuery query, CancellationToken cancellationToken)
            {
                var claim = await _itemRepository.GetByIdAsync(query.Id);
                if (claim == null)
                {
                    throw new ApiException($"Item not Found.");
                }
                else
                {
                    var mappedClaim = _mapper.Map<GetExpenseItemByIdResponse>(claim);
                    return new Response<GetExpenseItemByIdResponse>(mappedClaim);
                }

            }
        }

    }
}
