using AutoMapper;
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

namespace ExpenseClaims.Application.Features.ExpenseCategories.Quries.GetById
{
    public class GetExpenseCategoryByIdQuery : IRequest<Response<GetExpenseCategoryByIdResponse>>
    {
        public int Id { get; set; }

        public class GetExpenseCategoryByIdQueryHandler : IRequestHandler<GetExpenseCategoryByIdQuery, Response<GetExpenseCategoryByIdResponse>>
        {
            private readonly IExpenseCategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public GetExpenseCategoryByIdQueryHandler(IExpenseCategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<Response<GetExpenseCategoryByIdResponse>> Handle(GetExpenseCategoryByIdQuery query, CancellationToken cancellationToken)
            {
                var category = await _categoryRepository.GetByIdAsync(query.Id);
                if (category == null)
                {
                    throw new ApiException($"Category not Found.");
                }
                else
                {
                    var mappedCategory = _mapper.Map<GetExpenseCategoryByIdResponse>(category);
                    return new Response<GetExpenseCategoryByIdResponse>(mappedCategory);
                }

            }
        }
    }
}
