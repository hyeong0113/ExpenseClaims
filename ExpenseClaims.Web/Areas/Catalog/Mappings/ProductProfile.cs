using ExpenseClaims.Application.Features.Products.Commands.Create;
using ExpenseClaims.Application.Features.Products.Commands.Update;
using ExpenseClaims.Application.Features.Products.Queries.GetAllCached;
using ExpenseClaims.Application.Features.Products.Queries.GetById;
using ExpenseClaims.Web.Areas.Catalog.Models;
using AutoMapper;

namespace ExpenseClaims.Web.Areas.Catalog.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<GetAllProductsCachedResponse, ProductViewModel>().ReverseMap();
            CreateMap<GetProductByIdResponse, ProductViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, ProductViewModel>().ReverseMap();
            CreateMap<UpdateProductCommand, ProductViewModel>().ReverseMap();
        }
    }
}