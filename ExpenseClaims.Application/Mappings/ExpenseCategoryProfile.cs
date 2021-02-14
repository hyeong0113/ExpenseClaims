using AutoMapper;
using ExpenseClaims.Application.Features.ExpenseCategories.Commands.Create;
using ExpenseClaims.Application.Features.ExpenseCategories.Quries.GetAll;
using ExpenseClaims.Application.Features.ExpenseCategories.Quries.GetById;
using ExpenseClaims.Domain.Entities.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseClaims.Application.Mappings
{
    public class ExpenseCategoryProfile : Profile
    {
        public ExpenseCategoryProfile()
        {
            CreateMap<CreateExpenseCategoryCommand, ExpenseCategory>().ReverseMap();
            CreateMap<GetExpenseCategoryByIdResponse, ExpenseCategory>().ReverseMap();
            CreateMap<GetAllExpenseCategoriesResponse, ExpenseCategory>().ReverseMap();
        }
    }
}
