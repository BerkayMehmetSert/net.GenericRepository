using API.Application.Requests.Categories;
using API.Application.Responses.Categories;
using API.Application.Services.Categories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpPost]
        public ActionResult CreateCategory([FromBody] CreateCategoryRequest request)
        {
            _service.CreateCategory(request);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCategory([FromRoute] Guid id, [FromBody] UpdateCategoryRequest request)
        {
            _service.UpdateCategory(id, request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCategory([FromRoute] Guid id)
        {
            _service.DeleteCategory(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<CategoryResponse> GetCategoryById([FromRoute] Guid id)
        {
            var response = _service.GetCategoryById(id);
            return Ok(response);
        }

        [HttpGet("name/{name}")]
        public ActionResult<CategoryResponse> GetCategoryByName([FromRoute] string name)
        {
            var response = _service.GetCategoryByName(name);
            return Ok(response);
        }

        [HttpGet]
        public ActionResult<List<CategoryResponse>> GetAllCategories()
        {
            var response = _service.GetAllCategories();
            return Ok(response);
        }
    }
}
