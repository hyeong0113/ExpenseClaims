using AutoMapper;
using ExpenseClaims.Application.Interfaces.Repositories;
using ExpenseClaims.Application.Wrappers;
using ExpenseClaims.Domain.Entities.Catalog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Application.Features.ExpenseClaims.Commands.Create
{
    public partial class CreateExpenseClaimCommand : IRequest<Response<int>>
    {
        public string Title { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime ApprovalDate { get; set; }
        public DateTime ProcessedDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public string RequesterComments { get; set; }
        public string ApproverComments { get; set; }
        public string FinanceComments { get; set; }
    }
    public class CreateExpenseClaimCommandHandler : IRequestHandler<CreateExpenseClaimCommand, Response<int>>
    {
        private readonly IExpenseClaimRepository _claimRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateExpenseClaimCommandHandler(IExpenseClaimRepository claimRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _claimRepository = claimRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateExpenseClaimCommand request, CancellationToken cancellationToken)
        {
            var claim = _mapper.Map<ExpenseClaim>(request);
            await _claimRepository.InsertAsync(claim);
            await _unitOfWork.Commit(cancellationToken);
            return new Response<int>(claim.Id);
        }
    }

}
