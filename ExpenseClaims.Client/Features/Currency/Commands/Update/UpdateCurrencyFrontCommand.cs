using ExpenseClaims.Client.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Features.Currency.Commands.Update
{
    public class UpdateCurrencyFrontCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public double Rate { get; set; }

        public class UpdateCurrencyFrontCommandHandler : IRequestHandler<UpdateCurrencyFrontCommand, bool>
        {
            private readonly ICurrencyService _currencyService;

            public UpdateCurrencyFrontCommandHandler(ICurrencyService currencyService)
            {
                _currencyService = currencyService;
            }

            public async Task<bool> Handle(UpdateCurrencyFrontCommand command, CancellationToken cancellationToken)
            {
                var currency = await _currencyService.UpdateCurrency(command.Id, command);
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
