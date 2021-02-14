using AutoMapper;
using ExpenseClaims.Application.Features.Currencies.Commands.Create;
using ExpenseClaims.Application.Features.Currencies.Quries.GetAll;
using ExpenseClaims.Application.Features.Currencies.Quries.GetById;
using ExpenseClaims.Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseClaims.Application.Mappings
{
    public class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            CreateMap<CreateCurrencyCommand, Currency>().ReverseMap();
            CreateMap<GetCurrencyByIdResponse, Currency>().ReverseMap();
            CreateMap<GetAllCurrenciesResponse, Currency>().ReverseMap();
        }
    }
}
