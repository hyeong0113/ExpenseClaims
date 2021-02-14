using AspNetCoreHero.Results;
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

namespace ExpenseClaims.Application.Features.ExpenseClaims.Queries.GetById
{
    public class GetExpenseClaimByIdQuery : IRequest<Response<GetExpenseClaimByIdResponse>>
    {

        public int Id { get; set; }

        public class GetExpenseClaimByIdQueryHandler : IRequestHandler<GetExpenseClaimByIdQuery, Response<GetExpenseClaimByIdResponse>>
        {
            private readonly IExpenseClaimRepository _claimRepository;
            private readonly IMapper _mapper;

            public GetExpenseClaimByIdQueryHandler(IExpenseClaimRepository claimRepository, IMapper mapper)
            {
                _claimRepository = claimRepository;
                _mapper = mapper;
            }

            public async Task<Response<GetExpenseClaimByIdResponse>> Handle(GetExpenseClaimByIdQuery query, CancellationToken cancellationToken)
            {
                var claim = await _claimRepository.GetByIdWithItemsAsync(query.Id);
                if (claim == null)
                {
                    throw new ApiException($"Claim not Found.");
                }
                else
                {
                    var mappedClaim = _mapper.Map<GetExpenseClaimByIdResponse>(claim);
                    return new Response<GetExpenseClaimByIdResponse>(mappedClaim);
                }

            }
        }
    }
}
