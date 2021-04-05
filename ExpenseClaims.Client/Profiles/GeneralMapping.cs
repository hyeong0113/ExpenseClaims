using AutoMapper;
using ExpenseClaims.Client.Services.Base;
using ExpenseClaims.Client.Features.Currency.Commands.Create;
using ExpenseClaims.Client.Features.Currency.Commands.Update;
using ExpenseClaims.Client.Features.ExpenseCategory.Commands.Create;
using ExpenseClaims.Client.Features.ExpenseCategory.Commands.Update;
using ExpenseClaims.Client.Features.ExpenseClaim.Commands.Create;
using ExpenseClaims.Client.Features.ExpenseClaim.Commands.Update;
using ExpenseClaims.Client.Features.ExpenseItem.Commands.Create;
using ExpenseClaims.Client.Features.ExpenseItem.Commands.Update;
using ExpenseClaims.Client.ViewModels;

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
            CreateMap<CreateExpenseClaimFrontCommand, CreateExpenseClaimCommand>().ReverseMap();
            CreateMap<UpdateExpenseClaimFrontCommand, UpdateExpenseClaimCommand>().ReverseMap();
            CreateMap<ExpenseClaimDetailVM, UpdateExpenseClaimFrontCommand>().ReverseMap();

            // ExpenseItem Mapping
            CreateMap<ExpenseItemListVM, GetAllExpenseItemsResponse>().ReverseMap();
            CreateMap<ExpenseItemDetailVM, GetExpenseItemByIdResponse>().ReverseMap()
                .ForMember(vm => vm.Date, m => m.MapFrom(vm => vm.Date.DateTime));
            CreateMap<CreateExpenseItemFrontCommand, CreateExpenseItemCommand>().ReverseMap();
            CreateMap<UpdateExpenseItemFrontCommand, UpdateExpenseItemCommand>().ReverseMap();
            CreateMap<ExpenseItemDetailVM, CreateExpenseItemFrontCommand>().ReverseMap();
            CreateMap<ExpenseItemDetailVM, UpdateExpenseItemFrontCommand>().ReverseMap();

            // ExpenseCategory Mapping
            CreateMap<ExpenseCategoryListVM, GetAllExpenseCategoriesResponse>().ReverseMap();
            CreateMap<ExpenseCategoryDetailVM, GetExpenseCategoryByIdResponse>().ReverseMap();
            CreateMap<CreateExpenseCategoryFrontCommand, CreateExpenseCategoryCommand>().ReverseMap();
            CreateMap<UpdateExpenseCategoryFrontCommand, UpdateExpenseCategoryCommand>().ReverseMap();
            CreateMap<ExpenseCategoryDetailVM, UpdateExpenseCategoryFrontCommand>().ReverseMap();

            // Currency Mapping
            CreateMap<CurrencyListVM, GetAllCurrenciesResponse>().ReverseMap();
            CreateMap<CurrencyDetailVM, GetCurrencyByIdResponse>().ReverseMap();
            CreateMap<CreateCurrencyFrontCommand, CreateCurrencyCommand>().ReverseMap();
            CreateMap<UpdateCurrencyFrontCommand, UpdateCurrencyCommand>().ReverseMap();
            CreateMap<CurrencyDetailVM, UpdateCurrencyFrontCommand>().ReverseMap();

            // Users Mapping
            CreateMap<UserResponseVM, UserResponse>().ReverseMap();
        }
    }
}
