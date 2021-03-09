using AutoMapper;
using ExpenseClaims.Client.Services.Base;
using ExpenseClaims.Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseClaims.Client.Profiles
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            // ExpenseClaim Mapping
            CreateMap<ExpenseClaimListVM, GetAllExpenseClaimsResponse>().ReverseMap();
            CreateMap<ExpenseClaimDetailVM, GetExpenseClaimByIdResponse>().ReverseMap();
            CreateMap<ExpenseClaimDetailVM, CreateExpenseClaimCommand>().ReverseMap();
            CreateMap<ExpenseClaimDetailVM, UpdateExpenseClaimCommand>().ReverseMap();

            // ExpenseItem Mapping
            CreateMap<ExpenseItemListVM, GetAllExpenseItemsResponse>().ReverseMap();
            CreateMap<ExpenseItemDetailVM, GetExpenseItemByIdResponse>().ReverseMap();
            CreateMap<ExpenseItemDetailVM, CreateExpenseItemCommand>().ReverseMap();
            CreateMap<ExpenseItemDetailVM, UpdateExpenseItemCommand>().ReverseMap();

            // ExpenseCategory Mapping
            CreateMap<ExpenseCategoryListVM, GetAllExpenseCategoriesResponse>().ReverseMap();
            CreateMap<ExpenseCategoryDetailVM, GetExpenseCategoryByIdResponse>().ReverseMap();
            CreateMap<ExpenseCategoryDetailVM, CreateExpenseCategoryCommand>().ReverseMap();
            CreateMap<ExpenseCategoryDetailVM, UpdateExpenseCategoryCommand>().ReverseMap();

            // Currency Mapping
            CreateMap<CurrencyListVM, GetAllCurrenciesResponse>().ReverseMap();
            CreateMap<CurrencyDetailVM, GetCurrencyByIdResponse>().ReverseMap();
            CreateMap<CurrencyDetailVM, CreateCurrencyCommand>().ReverseMap();
            CreateMap<CurrencyDetailVM, UpdateCurrencyCommand>().ReverseMap();
        }
    }
}
