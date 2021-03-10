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
            CreateMap<ExpenseClaimDetailVM, GetExpenseClaimByIdResponse>().ReverseMap()
                .ForMember(vm => vm.SubmitDate, m => m.MapFrom(vm => vm.SubmitDate.DateTime))
                .ForMember(vm => vm.ApprovalDate, m => m.MapFrom(vm => vm.ApprovalDate.DateTime))
                .ForMember(vm => vm.ProcessedDate, m => m.MapFrom(vm => vm.ProcessedDate.DateTime))
                .ForMember(vm => vm.Items, m => m.MapFrom(vm => vm.Items));
            CreateMap<ExpenseClaimDetailVM, CreateExpenseClaimCommand>().ReverseMap();
            CreateMap<ExpenseClaimDetailVM, UpdateExpenseClaimCommand>().ReverseMap();

            // ExpenseItem Mapping
            CreateMap<ExpenseItemListVM, GetAllExpenseItemsResponse>().ReverseMap();
            CreateMap<ExpenseItemDetailVM, GetExpenseItemByIdResponse>().ReverseMap()
                .ForMember(vm => vm.Date, m => m.MapFrom(vm => vm.Date.DateTime));
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
