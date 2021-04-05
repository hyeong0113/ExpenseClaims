using ExpenseClaims.Client.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Features.Currency.Commands.Create
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
                return currency.Success;
            }
        }
    }
}
