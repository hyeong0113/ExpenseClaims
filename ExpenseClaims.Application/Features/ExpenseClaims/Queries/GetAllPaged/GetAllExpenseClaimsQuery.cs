using AspNetCoreHero.Results;
using AutoMapper;
using ExpenseClaims.Application.Extensions;
using ExpenseClaims.Application.Interfaces.Repositories;
using ExpenseClaims.Application.Wrappers;
using ExpenseClaims.Domain.Entities.Catalog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Application.Features.ExpenseClaims.Queries.GetAllPaged
{
    public class GetAllExpenseClaimsQuery : IRequest<Response<IEnumerable<GetAllExpenseClaimsResponse>>>
    {

        public class GetAllExpenseClaimsQueryHandler : IRequestHandler<GetAllExpenseClaimsQuery, Response<IEnumerable<GetAllExpenseClaimsResponse>>>
        {
            private readonly IExpenseClaimRepository _claimRepository;
            private readonly IMapper _mapper;

            public GetAllExpenseClaimsQueryHandler(IExpenseClaimRepository claimRepository, IMapper mapper)
            {
                _claimRepository = claimRepository;
                _mapper = mapper;
            }

            public async Task<Response<IEnumerable<GetAllExpenseClaimsResponse>>> Handle(GetAllExpenseClaimsQuery request, CancellationToken cancellationToken)
            {
                var claimList = await _claimRepository.GetListAsync();
                var mappedClaimList = _mapper.Map<IEnumerable<GetAllExpenseClaimsResponse>>(claimList);
                return new Response<IEnumerable<GetAllExpenseClaimsResponse>>(mappedClaimList);
            }
        }
    }


}
