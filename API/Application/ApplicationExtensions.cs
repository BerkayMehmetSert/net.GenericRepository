using System.Reflection;
using API.Application.Services.Categories;
using API.Application.Services.Products;

namespace API.Application
{
    public static class ApplicationExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IProductService, ProductManager>();
        }
    }
}
