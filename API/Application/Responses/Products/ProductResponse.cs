using API.Application.Responses.Categories;

namespace API.Application.Responses.Products
{
    public class ProductResponse : BaseResponse
    {
        public double Price { get; set; }
        public CategoryResponse Category { get; set; }
    }
}
