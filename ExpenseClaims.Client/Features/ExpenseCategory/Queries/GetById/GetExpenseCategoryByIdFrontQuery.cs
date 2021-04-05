using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Features.ExpenseCategory.Queries.GetById
{
    public class GetExpenseCategoryByIdFrontQuery : IRequest<ExpenseCategoryDetailVM>
    {
        public int Id { get; set; }

        public class GetExpenseCategoryByIdFrontQueryHandler : IRequestHandler<GetExpenseCategoryByIdFrontQuery, ExpenseCategoryDetailVM>
        {
            private readonly IExpenseCategoryService _categoryService;

            public GetExpenseCategoryByIdFrontQueryHandler(IExpenseCategoryService categoryService)
            {
                _categoryService = categoryService;
            }

            public async Task<ExpenseCategoryDetailVM> Handle(GetExpenseCategoryByIdFrontQuery query, CancellationToken cancellationToken)
            {
                var currency = await _categoryService.GetExpenseCategoryById(query.Id);
                if (currency == null)
                {
                    throw new NullReferenceException($"Currency not Found.");
                }
                else
                {
                    return currency;
                }
            }
        }
    }
}
