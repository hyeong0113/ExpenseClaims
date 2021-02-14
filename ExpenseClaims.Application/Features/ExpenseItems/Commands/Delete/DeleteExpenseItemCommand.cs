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

namespace ExpenseClaims.Application.Features.ExpenseItems.Commands.Delete
{
    public class DeleteExpenseItemCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }

        public class DeleteExpenseItemCommandHandler : IRequestHandler<DeleteExpenseItemCommand, Response<int>>
        {
            private readonly IExpenseItemRepository _itemRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteExpenseItemCommandHandler(IExpenseItemRepository itemRepository, IUnitOfWork unitOfWork)
            {
                _itemRepository = itemRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Response<int>> Handle(DeleteExpenseItemCommand request, CancellationToken cancellationToken)
            {
                var item = await _itemRepository.GetByIdAsync(request.Id);
                if (item == null)
                {
                    throw new ApiException("Item not Found.");
                }
                await _itemRepository.DeleteAsync(item);
                await _unitOfWork.Commit(cancellationToken);
                return new Response<int>(item.Id);
            }
        }
    }
}
