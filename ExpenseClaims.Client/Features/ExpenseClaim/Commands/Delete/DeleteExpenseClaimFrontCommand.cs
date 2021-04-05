using ExpenseClaims.Client.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Features.ExpenseClaim.Commands.Delete
{
    public class DeleteExpenseClaimFrontCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public class DeleteExpenseClaimFrontCommandHandler : IRequestHandler<DeleteExpenseClaimFrontCommand, bool>
        {
            private readonly IExpenseClaimService _claimService;

            public DeleteExpenseClaimFrontCommandHandler(IExpenseClaimService claimService)
            {
                _claimService = claimService;
            }

            public async Task<bool> Handle(DeleteExpenseClaimFrontCommand command, CancellationToken cancellationToken)
            {
                var claim = await _claimService.DeleteExpenseClaim(command.Id);
                if (claim == null)
                {
                    throw new NullReferenceException($"Claim not Found.");
                }
                else
                {
                    return claim.Success;
                }
            }
        }
    }
}
