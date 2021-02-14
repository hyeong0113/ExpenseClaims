using AspNetCoreHero.Results;
using ExpenseClaims.Application.Extensions;
using ExpenseClaims.Application.Interfaces.Repositories;
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
    public class GetAllExpenseClaimsQuery : IRequest<PaginatedResult<GetAllExpenseClaimsResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllExpenseClaimsQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    public class GetAllExpenseClaimsQueryHandler : IRequestHandler<GetAllExpenseClaimsQuery, PaginatedResult<GetAllExpenseClaimsResponse>>
    {
        private readonly IExpenseClaimRepository _claimRepository;

        public GetAllExpenseClaimsQueryHandler(IExpenseClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }

        public async Task<PaginatedResult<GetAllExpenseClaimsResponse>> Handle(GetAllExpenseClaimsQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<ExpenseClaim, GetAllExpenseClaimsResponse>> expression = e => new GetAllExpenseClaimsResponse
            {
                Id = e.Id,
                Title = e.Title,
                //Requester = e.Requester,
                //Approver = e.Approver,
                SubmitDate = e.SubmitDate,
                ApprovalDate = e.ApprovalDate,
                ProcessedDate = e.ProcessedDate,
                TotalAmount = e.TotalAmount,
                Status = e.Status,
                RequesterComments = e.RequesterComments,
                ApproverComments = e.ApproverComments,
                FinanceComments = e.FinanceComments
            };
            var paginatedList = await _claimRepository.Claims
                .Select(expression)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }
    }

}
