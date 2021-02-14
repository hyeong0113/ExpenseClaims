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

namespace ExpenseClaims.Application.Features.ExpenseItems.Commands.Create
{
    public partial class CreateExpenseItemCommand : IRequest<Response<int>>
    {
        public int ClaimId { get; set; }
        public int CategoryId { get; set; }
        public int CurrencyId { get; set; }
        public string Payee { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public decimal USDAmount { get; set; }
    }

    public class CreateExpenseItemCommandHandler : IRequestHandler<CreateExpenseItemCommand, Response<int>>
    {
        private readonly IExpenseItemRepository _itemRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateExpenseItemCommandHandler(IExpenseItemRepository itemRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateExpenseItemCommand request, CancellationToken cancellationToken)
        {
            var item = _mapper.Map<ExpenseItem>(request);
            await _itemRepository.InsertAsync(item);
            await _unitOfWork.Commit(cancellationToken);
            return new Response<int>(item.Id);
        }
    }
}
