using AutoMapper;
using ExpenseClaims.Application.Interfaces.Repositories;
using ExpenseClaims.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Application.Features.ExpenseCategories.Quries.GetAll
{
    public class GetAllExpenseCategoriesQuery : IRequest<Response<IEnumerable<GetAllExpenseCategoriesResponse>>>
    {
        public class GetAllExpenseCategoriesQueryHandler : IRequestHandler<GetAllExpenseCategoriesQuery, Response<IEnumerable<GetAllExpenseCategoriesResponse>>>
        {
            private readonly IExpenseCategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public GetAllExpenseCategoriesQueryHandler(IExpenseCategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository = categoryRepository;
                _mapper = mapper;
            }

            public async Task<Response<IEnumerable<GetAllExpenseCategoriesResponse>>> Handle(GetAllExpenseCategoriesQuery request, CancellationToken cancellationToken)
            {
                var categoryList = await _categoryRepository.GetAllAsync();
                var categoryMappedList = _mapper.Map<IEnumerable<GetAllExpenseCategoriesResponse>>(categoryList);
                return new Response<IEnumerable<GetAllExpenseCategoriesResponse>>(categoryMappedList);
            }
        }
    }
}
