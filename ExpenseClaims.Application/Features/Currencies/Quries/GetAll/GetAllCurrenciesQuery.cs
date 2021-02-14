using AutoMapper;
using ExpenseClaims.Application.Interfaces.Repositories;
using ExpenseClaims.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Application.Features.Currencies.Quries.GetAll
{
    public class GetAllCurrenciesQuery : IRequest<Response<IEnumerable<GetAllCurrenciesResponse>>>
    {
        public class GetAllCurrenciesQueryHandler : IRequestHandler<GetAllCurrenciesQuery, Response<IEnumerable<GetAllCurrenciesResponse>>>
        {
            private readonly ICurrencyRepository _currencyRepository;
            private readonly IMapper _mapper;

            public GetAllCurrenciesQueryHandler(ICurrencyRepository currencyRepository, IMapper mapper)
            {
                _currencyRepository = currencyRepository;
                _mapper = mapper;
            }

            public async Task<Response<IEnumerable<GetAllCurrenciesResponse>>> Handle(GetAllCurrenciesQuery request, CancellationToken cancellationToken)
            {
                var currencyList = await _currencyRepository.GetAllAsync();
                var currencyMappedList = _mapper.Map<IEnumerable<GetAllCurrenciesResponse>>(currencyList);
                return new Response<IEnumerable<GetAllCurrenciesResponse>>(currencyMappedList);
            }
        }
    }
}
