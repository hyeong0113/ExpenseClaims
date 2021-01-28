using ExpenseClaims.Application.Features.Brands.Commands.Create;
using ExpenseClaims.Application.Features.Brands.Queries.GetAllCached;
using ExpenseClaims.Application.Features.Brands.Queries.GetById;
using ExpenseClaims.Domain.Entities.Catalog;
using AutoMapper;

namespace ExpenseClaims.Application.Mappings
{
    internal class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<CreateBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsCachedResponse, Brand>().ReverseMap();
        }
    }
}