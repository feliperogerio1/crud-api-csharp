using crud_api.Interfaces.IRepositories;
using crud_api.Interfaces.IServices;
using crud_api.Models.Entities;
using crud_api.Utils;

namespace crud_api.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<Result<Product>> Insert(Product product)
        {
            product.CreatedDate = DateTime.Now;
            var (isValid, errors) = product.IsValid();
            if (!isValid)
                return Task.FromResult(Result.Failure<Product>(errors));

            product.Id = _productRepository.Add(product);
            return Task.FromResult(Result.Success(product));
        }

        public Task<Result<List<Product>>> Get()
        {
            var products = _productRepository.GetAll();
            return Task.FromResult(Result.Success(products));
        }

        public Task<Result<Product?>> Get(int id)
        {
            var product = _productRepository.GetById(id);
            return Task.FromResult(Result.Success(product));
        }

        public Task<Result<Product>> Update(int id, Product product)
        {
            var currentProduct = _productRepository.GetById(id);
            if (currentProduct is null)
                return Task.FromResult(Result.Failure<Product>("Product not found"));

            currentProduct.Name = product.Name;
            currentProduct.Price = product.Price;
            _productRepository.Update(currentProduct);

            return Task.FromResult(Result.Success(currentProduct));
        }

        public Task<Result<string>> Delete(int id)
        {
            var currentProduct = _productRepository.GetById(id);
            if (currentProduct is null)
                return Task.FromResult(Result.Failure<string>("Product not found"));

            _productRepository.Delete(id);

            return Task.FromResult(Result.Success("Ok"));
        }
    }
}
