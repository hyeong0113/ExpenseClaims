using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Services.Features.ExpenseClaimService.Queries.GetById
{
    public class GetExpenseClaimByIdFrontQuery : IRequest<ExpenseClaimDetailVM>
    {
        public int Id { get; set; }

        public class GetExpenseClaimByIdFrontQueryHandler : IRequestHandler<GetExpenseClaimByIdFrontQuery, ExpenseClaimDetailVM>
        {
            private readonly IExpenseClaimService _clalimService;

            public GetExpenseClaimByIdFrontQueryHandler(IExpenseClaimService clalimService)
            {
                _clalimService = clalimService;
            }

            public async Task<ExpenseClaimDetailVM> Handle(GetExpenseClaimByIdFrontQuery query, CancellationToken cancellationToken)
            {
                var claim = await _clalimService.GetExpenseClaimById(query.Id);
                if (claim == null)
                {
                    throw new NullReferenceException($"Currency not Found.");
                }
                else
                {
                    return claim;
                }
            }
        }
    }
}
