using API.Application.Repositories;
using API.Application.Requests.Products;
using API.Application.Responses.Products;
using API.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using static API.Application.Constants.ProductMessage;

namespace API.Application.Services.Products
{
    public class ProductManager : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateProduct(CreateProductRequest request)
        {
            CheckIfProductExistsByName(request.Name);

            var product = _mapper.Map<Product>(request);

            _unitOfWork.ProductRepository.Create(product);
            _unitOfWork.SaveChanges();
        }

        public void UpdateProduct(Guid id, UpdateProductRequest request)
        {
            var product = GetProduct(id);

            if (product.Name != request.Name)
            {
                CheckIfProductExistsByName(request.Name);
            }

            var updatedProduct = _mapper.Map(request, product);

            _unitOfWork.ProductRepository.Update(updatedProduct);
            _unitOfWork.SaveChanges();
        }

        public void UpdateProductByCategory(Guid id, Guid categoryId)
        {
            var product = GetProduct(id);

            product.CategoryId = categoryId;

            _unitOfWork.ProductRepository.Update(product);
            _unitOfWork.SaveChanges();
        }

        public void DeleteProduct(Guid id)
        {
            var product = GetProduct(id);

            _unitOfWork.ProductRepository.Delete(product);
            _unitOfWork.SaveChanges();
        }

        public ProductResponse GetProductById(Guid id)
        {
            var product = GetProduct(id);

            var response = _mapper.Map<ProductResponse>(product);
            return response;
        }

        public ProductResponse GetProductByName(string name)
        {
            var product = _unitOfWork.ProductRepository.Get(
                predicate: x => x.Name == name,
                include: x => x.Include(y => y.Category)
                );

            if (product is null)
            {
                throw new Exception(ProductNotFound);
            }

            var response = _mapper.Map<ProductResponse>(product);
            return response;
        }

        public List<ProductResponse> GetAllProducts()
        {
            var products = _unitOfWork.ProductRepository.GetAll(
                include: x => x.Include(y => y.Category),
                orderBy: q => q.OrderByDescending(p => p.CreatedAt)
                );

            if (products.Count == 0)
            {
                throw new Exception(ProductListEmpty);
            }

            var response = _mapper.Map<List<ProductResponse>>(products);
            return response;
        }

        public List<ProductResponse> GetProductsByPriceDescending()
        {
            var products = _unitOfWork.ProductRepository.GetAll(
                include: x => x.Include(y => y.Category),
                orderBy: q => q.OrderByDescending(p => p.Price)
                );

            if (products.Count == 0)
            {
                throw new Exception(ProductListEmpty);
            }

            var response = _mapper.Map<List<ProductResponse>>(products);
            return response;
        }

        public List<ProductResponse> GetProductsByPriceAscending()
        {
            var products = _unitOfWork.ProductRepository.GetAll(
                include: x => x.Include(y => y.Category),
                orderBy: q => q.OrderBy(p => p.Price)
                );

            if (products.Count == 0)
            {
                throw new Exception(ProductListEmpty);
            }

            var response = _mapper.Map<List<ProductResponse>>(products);
            return response;
        }

        private void CheckIfProductExistsByName(string name)
        {
            name = name.ToLower();
            var product = _unitOfWork.ProductRepository.Get(x => x.Name == name);

            if (product is not null)
            {
                throw new Exception(ProductAlreadyExists);
            }
        }

        private Product GetProduct(Guid id)
        {
            var product = _unitOfWork.ProductRepository.Get(
                predicate: x => x.Id == id,
                include: x => x.Include(y => y.Category));

            if (product is null)
            {
                throw new Exception(ProductNotFound);
            }

            return product;
        }
    }
}
