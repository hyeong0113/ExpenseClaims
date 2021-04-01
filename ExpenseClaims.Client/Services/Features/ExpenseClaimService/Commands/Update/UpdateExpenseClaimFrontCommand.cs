using ExpenseClaims.Client.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Services.Features.ExpenseClaimService.Commands.Update
{
    public class UpdateExpenseClaimFrontCommand : IRequest<int>
    {
        public int Id { get; set; }
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

        public class UpdateExpenseClaimFrontCommandHandler : IRequestHandler<UpdateExpenseClaimFrontCommand, int>
        {
            private readonly IExpenseClaimService _claimService;

            public UpdateExpenseClaimFrontCommandHandler(IExpenseClaimService claimService)
            {
                _claimService = claimService;
            }

            public async Task<int> Handle(UpdateExpenseClaimFrontCommand command, CancellationToken cancellationToken)
            {
                var claim = await _claimService.UpdateExpenseClaim(command.Id, command);
                if (claim == null)
                {
                    throw new NullReferenceException($"Category not Found.");
                }
                else
                {
                    return claim.Data;
                }
            }
        }
    }
}
