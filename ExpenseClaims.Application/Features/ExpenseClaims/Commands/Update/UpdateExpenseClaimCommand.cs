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

namespace ExpenseClaims.Application.Features.ExpenseClaims.Commands.Update
{
    public class UpdateExpenseClaimCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public DateTime ProcessedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string RequesterComments { get; set; }
        public string ApproverComments { get; set; }
        public string FinanceComments { get; set; }

        public class UpdateExpenseClaimCommandHandler : IRequestHandler<UpdateExpenseClaimCommand, Response<int>>
        {
            private readonly IExpenseClaimRepository _claimRepository;
            private readonly IUnitOfWork _unitOfWork;

            public UpdateExpenseClaimCommandHandler(IExpenseClaimRepository claimRepository, IUnitOfWork unitOfWork)
            {
                _claimRepository = claimRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Response<int>> Handle(UpdateExpenseClaimCommand request, CancellationToken cancellationToken)
            {
                var claim = await _claimRepository.GetByIdAsync(request.Id);
                if (claim == null)
                {
                    throw new ApiException("Expense claim not Found.");
                }
                else
                {
                    claim.Title = request.Title;
                    claim.SubmitDate = request.SubmitDate;
                    claim.ApprovalDate = request.ApprovalDate;
                    claim.ProcessedDate = request.ProcessedDate;
                    claim.TotalAmount = request.TotalAmount;
                    claim.Status = request.Status;
                    claim.RequesterComments = request.RequesterComments;
                    claim.ApproverComments = request.ApproverComments;
                    claim.FinanceComments = request.FinanceComments;

                    await _claimRepository.UpdateAsync(claim);
                    await _unitOfWork.Commit(cancellationToken);
                    return new Response<int>(claim.Id);
                }
            }

        }
    }
}
