using ExpenseClaims.Client.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Features.Currency.Commands.Delete
{
    public class DeleteCurrencyFrontCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public class DeleteCurrencyFrontCommandHandler : IRequestHandler<DeleteCurrencyFrontCommand, bool>
        {
            private readonly ICurrencyService _currencyService;

            public DeleteCurrencyFrontCommandHandler(ICurrencyService currencyService)
            {
                _currencyService = currencyService;
            }

            public async Task<bool> Handle(DeleteCurrencyFrontCommand command, CancellationToken cancellationToken)
            {
                var currency = await _currencyService.DeleteCurrency(command.Id);
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
