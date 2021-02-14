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

namespace ExpenseClaims.Application.Features.Currencies.Commands.Update
{
    public class UpdateCurrencyCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Rate { get; set; }

        public class UpdateCurrencyCommandCommandHandler : IRequestHandler<UpdateCurrencyCommand, Response<int>>
        {
            private readonly ICurrencyRepository _currencyRepository;
            private readonly IUnitOfWork _unitOfWork;

            public UpdateCurrencyCommandCommandHandler(ICurrencyRepository currencyRepository, IUnitOfWork unitOfWork)
            {
                _currencyRepository = currencyRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Response<int>> Handle(UpdateCurrencyCommand request, CancellationToken cancellationToken)
            {
                var currency = await _currencyRepository.GetByIdAsync(request.Id);
                if (currency == null)
                {
                    throw new ApiException("Currency not Found.");
                }
                else
                {
                    currency.Name = request.Name;
                    currency.Code = request.Code;

                    await _currencyRepository.UpdateAsync(currency);
                    await _unitOfWork.Commit(cancellationToken);
                    return new Response<int>(currency.Id);
                }
            }
        }

    }
}
