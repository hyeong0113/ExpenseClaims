using ExpenseClaims.Client.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Features.ExpenseClaim.Commands.Create
{
    public class CreateExpenseClaimFrontCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string RequesterId { get; set; }
        public string ApproverId { get; set; }
        public DateTime? SubmitDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public double TotalAmount { get; set; }
        public string Status { get; set; }
        public string RequesterComments { get; set; }
        public string ApproverComments { get; set; }
        public string FinanceComments { get; set; }

        public class CreateExpenseClaimFrontCommandHandler : IRequestHandler<CreateExpenseClaimFrontCommand, int>
        {
            private readonly IExpenseClaimService _claimService;

            public CreateExpenseClaimFrontCommandHandler(IExpenseClaimService claimService)
            {
                _claimService = claimService;
            }

            public async Task<int> Handle(CreateExpenseClaimFrontCommand command, CancellationToken cancellationToken)
            {
                var claim = await _claimService.CreateExpenseClaim(command);
                return claim.Data;
            }
        }
    }
}
