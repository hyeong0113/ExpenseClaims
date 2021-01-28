using ExpenseClaims.Application.Features.Brands.Commands.Create;
using ExpenseClaims.Application.Features.Brands.Commands.Update;
using ExpenseClaims.Application.Features.Brands.Queries.GetAllCached;
using ExpenseClaims.Application.Features.Brands.Queries.GetById;
using ExpenseClaims.Web.Areas.Catalog.Models;
using AutoMapper;

namespace ExpenseClaims.Web.Areas.Catalog.Mappings
{
    internal class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<GetAllBrandsCachedResponse, BrandViewModel>().ReverseMap();
            CreateMap<GetBrandByIdResponse, BrandViewModel>().ReverseMap();
            CreateMap<CreateBrandCommand, BrandViewModel>().ReverseMap();
            CreateMap<UpdateBrandCommand, BrandViewModel>().ReverseMap();
        }
    }
}