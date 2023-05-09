using API.Application.Requests.Products;
using API.Application.Responses.Products;

namespace API.Application.Services.Products
{
    public interface IProductService
    {
        void CreateProduct(CreateProductRequest request);
        void UpdateProduct(Guid id, UpdateProductRequest request);
        void UpdateProductByCategory(Guid id, Guid categoryId);
        void DeleteProduct(Guid id);
        ProductResponse GetProductById(Guid id);
        ProductResponse GetProductByName(string name);
        List<ProductResponse> GetAllProducts();
        List<ProductResponse> GetProductsByPriceDescending();
        List<ProductResponse> GetProductsByPriceAscending();

    }
}
