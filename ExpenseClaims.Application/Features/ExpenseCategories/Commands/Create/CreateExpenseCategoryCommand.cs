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

namespace ExpenseClaims.Application.Features.ExpenseCategories.Commands.Create
{
    public partial class CreateExpenseCategoryCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public class CreateExpenseCategoryCommandHandler : IRequestHandler<CreateExpenseCategoryCommand, Response<int>>
        {
            private readonly IExpenseCategoryRepository _categoryRepository;
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;

            public CreateExpenseCategoryCommandHandler(IExpenseCategoryRepository categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<Response<int>> Handle(CreateExpenseCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = _mapper.Map<ExpenseCategory>(request);
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.Commit(cancellationToken);
                return new Response<int>(category.Id);
            }
        }
    }
}
