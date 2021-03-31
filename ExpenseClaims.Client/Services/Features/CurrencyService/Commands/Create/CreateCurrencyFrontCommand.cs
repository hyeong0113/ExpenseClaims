using ExpenseClaims.Client.Contracts;
using ExpenseClaims.Client.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Services.Features.CurrencyService.Commands.Create
{
    public class CreateCurrencyFrontCommand : IRequest<bool>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Rate { get; set; }

        public class CreateCurrencyFrontCommandHandler : IRequestHandler<CreateCurrencyFrontCommand, bool>
        {
            private readonly ICurrencyService _currencyService;

            public CreateCurrencyFrontCommandHandler(ICurrencyService currencyService)
            {
                _currencyService = currencyService;
            }

            public async Task<bool> Handle(CreateCurrencyFrontCommand command, CancellationToken cancellationToken)
            {
                var currency = await _currencyService.CreateCurrency(command);
                if (currency == null)
                {
                    throw new NullReferenceException($"Currency not Found.");
                }
                else
                {
                    return currency.Success;
                }
            }
        }
    }
}
