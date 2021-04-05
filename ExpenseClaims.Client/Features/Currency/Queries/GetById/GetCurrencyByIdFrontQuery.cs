using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Features.Currency.Queries.GetById
{
    public class GetCurrencyByIdFrontQuery : IRequest<CurrencyDetailVM>
    {
        public int Id { get; set; }

        public class GetCurrencyByIdQueryHandler : IRequestHandler<GetCurrencyByIdFrontQuery, CurrencyDetailVM>
        {
            private readonly ICurrencyService _currencyService;

            public GetCurrencyByIdQueryHandler(ICurrencyService currencyService)
            {
                _currencyService = currencyService;
            }

            public async Task<CurrencyDetailVM> Handle(GetCurrencyByIdFrontQuery query, CancellationToken cancellationToken)
            {
                var currency = await _currencyService.GetCurrencyById(query.Id);
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
