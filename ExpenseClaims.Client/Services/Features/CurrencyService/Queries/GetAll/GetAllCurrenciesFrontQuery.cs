using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Services.Features.CurrencyService.Queries.GetAll
{
    public class GetAllCurrenciesFrontQuery : IRequest<List<CurrencyListVM>>
    {

        public class GetAllCurrenciesFrontQueryHandler : IRequestHandler<GetAllCurrenciesFrontQuery, List<CurrencyListVM>>
        {
            private readonly ICurrencyService _currencyService;

            public GetAllCurrenciesFrontQueryHandler(ICurrencyService currencyService)
            {
                _currencyService = currencyService;
            }

            public async Task<List<CurrencyListVM>> Handle(GetAllCurrenciesFrontQuery query, CancellationToken cancellationToken)
            {
                var currencies = await _currencyService.GetAllCurrencies();
                return currencies;
            }
        }
    }
}
