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

namespace ExpenseClaims.Application.Features.Currencies.Commands.Delete
{
    public class DeleteCurrencyCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteCurrencyCommandCommandHandler : IRequestHandler<DeleteCurrencyCommand, Response<int>>
        {
            private readonly ICurrencyRepository _currencyRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteCurrencyCommandCommandHandler(ICurrencyRepository currencyRepository, IUnitOfWork unitOfWork)
            {
                _currencyRepository = currencyRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Response<int>> Handle(DeleteCurrencyCommand request, CancellationToken cancellationToken)
            {
                var currency = await _currencyRepository.GetByIdAsync(request.Id);
                if (currency == null)
                {
                    throw new ApiException("Currency not Found.");
                }
                await _currencyRepository.DeleteAsync(currency);
                await _unitOfWork.Commit(cancellationToken);
                return new Response<int>(currency.Id);
            }
        }
    }
}
