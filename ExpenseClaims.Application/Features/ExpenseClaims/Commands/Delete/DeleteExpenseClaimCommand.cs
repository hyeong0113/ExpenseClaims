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

namespace ExpenseClaims.Application.Features.ExpenseClaims.Commands.Delete
{
    public class DeleteExpenseClaimCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteExpenseClaimCommandHandler : IRequestHandler<DeleteExpenseClaimCommand, Response<int>>
        {
            private readonly IExpenseClaimRepository _claimRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteExpenseClaimCommandHandler(IExpenseClaimRepository claimRepository, IUnitOfWork unitOfWork)
            {
                _claimRepository = claimRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Response<int>> Handle(DeleteExpenseClaimCommand request, CancellationToken cancellationToken)
            {
                var claim = await _claimRepository.GetByIdAsync(request.Id);
                if (claim == null)
                {
                    throw new ApiException("Claim not Found.");
                }
                await _claimRepository.DeleteAsync(claim);
                await _unitOfWork.Commit(cancellationToken);
                return new Response<int>(claim.Id);
            }
        }
    }
}
