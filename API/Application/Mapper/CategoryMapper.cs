using API.Application.Requests.Categories;
using API.Application.Responses.Categories;
using API.Domain.Entities;
using AutoMapper;

namespace API.Application.Mapper
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<CreateCategoryRequest, Category>();
            CreateMap<UpdateCategoryRequest, Category>();
            CreateMap<Category, CategoryResponse>();
        }
    }
}
