using API.Application.Requests.Products;
using API.Application.Responses.Products;
using API.Domain.Entities;
using AutoMapper;

namespace API.Application.Mapper
{
    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<CreateProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();
            CreateMap<Product, ProductResponse>();
        }
    }
}
