using AutoMapper;
using ExpenseClaims.Application.Interfaces.Repositories;
using ExpenseClaims.Application.Wrappers;
using ExpenseClaims.Domain.Entities.Catalog;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExpenseClaims.Application.Features.Currencies.Commands.Create
{
    public partial class CreateCurrencyCommand : IRequest<Response<int>>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Rate { get; set; }
    }
    public class CreateCurrencyCommandHandler : IRequestHandler<CreateCurrencyCommand, Response<int>>
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCurrencyCommandHandler(ICurrencyRepository currencyRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _currencyRepository = currencyRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var currency = _mapper.Map<Currency>(request);
            await _currencyRepository.AddAsync(currency);
            await _unitOfWork.Commit(cancellationToken);
            return new Response<int>(currency.Id);
        }
    }

}
