using AutoMapper;
using ExpenseClaims.Application.Features.ExpenseClaims.Commands.Create;
using ExpenseClaims.Application.Features.ExpenseClaims.Queries.GetAllPaged;
using ExpenseClaims.Application.Features.ExpenseClaims.Queries.GetById;
using ExpenseClaims.Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseClaims.Application.Mappings
{
    internal class ExpenseClaimProfile : Profile
    {
        public ExpenseClaimProfile()
        {
            CreateMap<CreateExpenseClaimCommand, ExpenseClaim>().ReverseMap();
            CreateMap<GetExpenseClaimByIdResponse, ExpenseClaim>().ReverseMap()
                                .ForMember(vm => vm.Items, m => m.MapFrom(vm => vm.Items));
            CreateMap<GetAllExpenseClaimsResponse, ExpenseClaim>().ReverseMap();
        }
    }
}
