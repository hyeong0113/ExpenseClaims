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

namespace ExpenseClaims.Application.Features.ExpenseItems.Commands.Update
{
    public class UpdateExpenseItemCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CurrencyId { get; set; }
        public string Payee { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public decimal USDAmount { get; set; }

        public class UpdateExpenseItemCommandHandler : IRequestHandler<UpdateExpenseItemCommand, Response<int>>
        {
            private readonly IExpenseItemRepository _itemRepository;
            private readonly IUnitOfWork _unitOfWork;

            public UpdateExpenseItemCommandHandler(IExpenseItemRepository itemRepository, IUnitOfWork unitOfWork)
            {
                _itemRepository = itemRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Response<int>> Handle(UpdateExpenseItemCommand request, CancellationToken cancellationToken)
            {
                var item = await _itemRepository.GetByIdAsync(request.Id);
                if (item == null)
                {
                    throw new ApiException("Item not Found.");
                }
                else
                {
                    item.CategoryId = request.CategoryId;
                    item.CurrencyId = request.CurrencyId;
                    item.Payee = request.Payee;
                    item.Date = request.Date;
                    item.Description = request.Description;
                    item.Amount = request.Amount;
                    item.CurrencyCode = request.CurrencyCode;
                    item.USDAmount = request.USDAmount;

                    await _itemRepository.UpdateAsync(item);
                    await _unitOfWork.Commit(cancellationToken);
                    return new Response<int>(item.Id);
                }
            }

        }
    }
}
