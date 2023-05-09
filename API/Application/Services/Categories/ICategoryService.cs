using API.Application.Requests.Categories;
using API.Application.Responses.Categories;

namespace API.Application.Services.Categories
{
    public interface ICategoryService
    {
        void CreateCategory(CreateCategoryRequest request);
        void UpdateCategory(Guid id,UpdateCategoryRequest request);
        void DeleteCategory(Guid id);
        CategoryResponse GetCategoryById(Guid id);
        CategoryResponse GetCategoryByName(string name);
        List<CategoryResponse> GetAllCategories();
    }
}
