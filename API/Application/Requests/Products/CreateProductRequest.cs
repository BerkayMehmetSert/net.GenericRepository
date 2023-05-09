namespace API.Application.Requests.Products
{
    public class CreateProductRequest : BaseRequest
    {
        public Guid CategoryId { get; set; }
        public double Price { get; set; }
    }
}
