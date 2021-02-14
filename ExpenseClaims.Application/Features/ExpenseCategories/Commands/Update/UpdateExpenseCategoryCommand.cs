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

namespace ExpenseClaims.Application.Features.ExpenseCategories.Commands.Update
{
    public class UpdateExpenseCategoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public class UpdateExpenseCategoryCommandHandler : IRequestHandler<UpdateExpenseCategoryCommand, Response<int>>
        {
            private readonly IExpenseCategoryRepository _categoryRepository;
            private readonly IUnitOfWork _unitOfWork;

            public UpdateExpenseCategoryCommandHandler(IExpenseCategoryRepository categoryRepository, IUnitOfWork unitOfWork)
            {
                _categoryRepository = categoryRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Response<int>> Handle(UpdateExpenseCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = await _categoryRepository.GetByIdAsync(request.Id);
                if (category == null)
                {
                    throw new ApiException("Category not Found.");
                }
                else
                {
                    category.Name = request.Name;
                    category.Code = request.Code;

                    await _categoryRepository.UpdateAsync(category);
                    await _unitOfWork.Commit(cancellationToken);
                    return new Response<int>(category.Id);
                }
            }
        }
    }
}
