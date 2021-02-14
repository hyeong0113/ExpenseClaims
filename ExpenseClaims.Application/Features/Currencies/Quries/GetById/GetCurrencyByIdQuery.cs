using AutoMapper;
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

namespace ExpenseClaims.Application.Features.Currencies.Quries.GetById
{
    public class GetCurrencyByIdQuery : IRequest<Response<GetCurrencyByIdResponse>>
    {
        public int Id { get; set; }

        public class GetCurrencyByIdQueryHandler : IRequestHandler<GetCurrencyByIdQuery, Response<GetCurrencyByIdResponse>>
        {
            private readonly ICurrencyRepository _currencyRepository;
            private readonly IMapper _mapper;

            public GetCurrencyByIdQueryHandler(ICurrencyRepository currencyRepository, IMapper mapper)
            {
                _currencyRepository = currencyRepository;
                _mapper = mapper;
            }

            public async Task<Response<GetCurrencyByIdResponse>> Handle(GetCurrencyByIdQuery query, CancellationToken cancellationToken)
            {
                var currency = await _currencyRepository.GetByIdAsync(query.Id);
                if (currency == null)
                {
                    throw new ApiException($"Currency not Found.");
                }
                else
                {
                    var mappedCurrency = _mapper.Map<GetCurrencyByIdResponse>(currency);
                    return new Response<GetCurrencyByIdResponse>(mappedCurrency);
                }

            }
        }
    }
}
