using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Features.ExpenseClaim.Queries.GetAll
{
    public class GetAllExpenseClaimsFrontQuery : IRequest<List<ExpenseClaimListVM>>
    {
        public Claim Roles { get; set; }
        public string UserId { get; set; }

        public class GetAllExpenseClaimsFrontQueryHandler : IRequestHandler<GetAllExpenseClaimsFrontQuery, List<ExpenseClaimListVM>>
        {
            private readonly IExpenseClaimService _clalimService;

            public GetAllExpenseClaimsFrontQueryHandler(IExpenseClaimService clalimService)
            {
                _clalimService = clalimService;
            }

            public async Task<List<ExpenseClaimListVM>> Handle(GetAllExpenseClaimsFrontQuery query, CancellationToken cancellationToken)
            {
                var claims = await _clalimService.GetAllExpenseClaims(query.Roles, query.UserId);
                return claims;
            }
        }
    }
}
