using AutoMapper;
using ExpenseClaims.Application.Features.ExpenseItems.Commands.Create;
using ExpenseClaims.Application.Features.ExpenseItems.Queries.GetAll;
using ExpenseClaims.Application.Features.ExpenseItems.Queries.GetById;
using ExpenseClaims.Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseClaims.Application.Mappings
{
    internal class ExpenseitemProfile : Profile
    {
        public ExpenseitemProfile()
        {
            CreateMap<CreateExpenseItemCommand, ExpenseItem>().ReverseMap();
            CreateMap<GetExpenseItemByIdResponse, ExpenseItem>().ReverseMap();
            CreateMap<GetAllExpenseItemsResponse, ExpenseItem>().ReverseMap();
        }
    }
}
