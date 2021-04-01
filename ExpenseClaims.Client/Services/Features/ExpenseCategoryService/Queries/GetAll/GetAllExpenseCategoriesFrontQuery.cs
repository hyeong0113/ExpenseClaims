using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Services.Features.ExpenseCategoryService.Queries.GetAll
{
    public class GetAllExpenseCategoriesFrontQuery : IRequest<List<ExpenseCategoryListVM>>
    {

        public class GetAllExpenseCategoriesFrontQueryHandler : IRequestHandler<GetAllExpenseCategoriesFrontQuery, List<ExpenseCategoryListVM>>
        {
            private readonly IExpenseCategoryService _categoryService;

            public GetAllExpenseCategoriesFrontQueryHandler(IExpenseCategoryService categoryService)
            {
                _categoryService = categoryService;
            }

            public async Task<List<ExpenseCategoryListVM>> Handle(GetAllExpenseCategoriesFrontQuery query, CancellationToken cancellationToken)
            {
                var categories = await _categoryService.GetAllExpenseCategories();
                return categories;
            }
        }
    }
}
