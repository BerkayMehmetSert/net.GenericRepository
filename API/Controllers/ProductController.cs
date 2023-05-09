using API.Application.Requests.Products;
using API.Application.Responses.Products;
using API.Application.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult CreateProduct([FromBody] CreateProductRequest request)
        {
            _service.CreateProduct(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct([FromRoute] Guid id, [FromBody] UpdateProductRequest request)
        {
            _service.UpdateProduct(id, request);
            return Ok();
        }

        [HttpPut("{id}/category/{categoryId}")]
        public ActionResult UpdateProductByCategory([FromRoute] Guid id, [FromRoute] Guid categoryId)
        {
            _service.UpdateProductByCategory(id, categoryId);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct([FromRoute] Guid id)
        {
            _service.DeleteProduct(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<ProductResponse> GetProductById([FromRoute] Guid id)
        {
            var response = _service.GetProductById(id);
            return Ok(response);
        }

        [HttpGet("name/{name}")]
        public ActionResult<ProductResponse> GetProductByName([FromRoute] string name)
        {
            var response = _service.GetProductByName(name);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<List<ProductResponse>> GetAllProducts()
        {
            var response = _service.GetAllProducts();
            return Ok(response);
        }

        [HttpGet("price/descending")]
        public ActionResult<List<ProductResponse>> GetProductsByPriceDescending()
        {
            var response = _service.GetProductsByPriceDescending();
            return Ok(response);
        }

        [HttpGet("price/ascending")]
        public ActionResult<List<ProductResponse>> GetProductsByPriceAscending()
        {
            var response = _service.GetProductsByPriceAscending();
            return Ok(response);
        }
    }
}
