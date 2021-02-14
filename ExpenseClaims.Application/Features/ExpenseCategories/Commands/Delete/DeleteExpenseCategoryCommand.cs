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

namespace ExpenseClaims.Application.Features.ExpenseCategories.Commands.Delete
{
    public class DeleteExpenseCategoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteExpenseCategoryCommandHandler : IRequestHandler<DeleteExpenseCategoryCommand, Response<int>>
        {
            private readonly IExpenseCategoryRepository _categoryRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteExpenseCategoryCommandHandler(IExpenseCategoryRepository categoryRepository, IUnitOfWork unitOfWork)
            {
                _categoryRepository = categoryRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Response<int>> Handle(DeleteExpenseCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = await _categoryRepository.GetByIdAsync(request.Id);
                if (category == null)
                {
                    throw new ApiException("Category not Found.");
                }
                await _categoryRepository.DeleteAsync(category);
                await _unitOfWork.Commit(cancellationToken);
                return new Response<int>(category.Id);
            }
        }
    }
}
