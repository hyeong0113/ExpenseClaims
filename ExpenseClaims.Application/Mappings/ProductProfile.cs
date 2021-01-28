using ExpenseClaims.Application.Features.Products.Commands.Create;
using ExpenseClaims.Application.Features.Products.Queries.GetAllCached;
using ExpenseClaims.Application.Features.Products.Queries.GetAllPaged;
using ExpenseClaims.Application.Features.Products.Queries.GetById;
using ExpenseClaims.Domain.Entities.Catalog;
using AutoMapper;

namespace ExpenseClaims.Application.Mappings
{
    internal class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<GetProductByIdResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsCachedResponse, Product>().ReverseMap();
            CreateMap<GetAllProductsResponse, Product>().ReverseMap();
        }
    }
}