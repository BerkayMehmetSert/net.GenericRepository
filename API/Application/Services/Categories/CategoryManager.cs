using API.Application.Repositories;
using API.Application.Requests.Categories;
using API.Application.Responses.Categories;
using API.Domain.Entities;
using AutoMapper;
using static API.Application.Constants.CategoryMessage;

namespace API.Application.Services.Categories
{
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateCategory(CreateCategoryRequest request)
        {
            CheckIfCategoryExistsByName(request.Name);

            var category = _mapper.Map<Category>(request);

            _unitOfWork.CategoryRepository.Create(category);
            _unitOfWork.SaveChanges();
        }

        public void UpdateCategory(Guid id, UpdateCategoryRequest request)
        {
            var category = GetCategory(id);

            if (category.Name != request.Name)
            {
                CheckIfCategoryExistsByName(request.Name);
            }

            var updatedCategory = _mapper.Map(request, category);

            _unitOfWork.CategoryRepository.Update(updatedCategory);
            _unitOfWork.SaveChanges();
        }

        public void DeleteCategory(Guid id)
        {
            var category = GetCategory(id);

            _unitOfWork.CategoryRepository.Delete(category);
            _unitOfWork.SaveChanges();
        }

        public CategoryResponse GetCategoryById(Guid id)
        {
            var category = GetCategory(id);

            var response = _mapper.Map<CategoryResponse>(category);

            return response;
        }

        public CategoryResponse GetCategoryByName(string name)
        {
            var category = _unitOfWork.CategoryRepository.Get(x => x.Name == name);

            if (category is null)
            {
                throw new Exception(CategoryNotFound);
            }

            var response = _mapper.Map<CategoryResponse>(category);

            return response;
        }

        public List<CategoryResponse> GetAllCategories()
        {
            var categories = _unitOfWork.CategoryRepository.GetAll();

            if (categories.Count == 0)
            {
                throw new Exception(CategoryListEmpty);
            }

            var response = _mapper.Map<List<CategoryResponse>>(categories);

            return response;
        }

        private void CheckIfCategoryExistsByName(string name)
        {
            name = name.ToLower();
            var category = _unitOfWork.CategoryRepository.Get(x => x.Name == name);

            if (category is not null)
            {
                throw new Exception(CategoryAlreadyExists);
            }
        }

        private Category GetCategory(Guid id)
        {
            var category = _unitOfWork.CategoryRepository.Get(x => x.Id == id);
            return category ?? throw new Exception(CategoryNotFound);
        }
    }
}
