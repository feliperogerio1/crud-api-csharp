using CrudApi.Interfaces.Repositories;
using CrudApi.Interfaces.Services;
using CrudApi.Models.Entities;
using CrudApi.Utils;

namespace CrudApi.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<Product>> Insert(Product product)
    {
        product.Id = await _productRepository.Insert(product);
        return Result.Success<Product>(product);
    }

    public async Task<Result<Product>> Get(int id)
    {
        var product = await _productRepository.Get(id);
        if (product is null)
            return Result.Failure<Product>("Product not found");

        return Result.Success<Product>(product);
    }

    public async Task<Result<List<Product>>> Get(int pageNumber, int pageSize)
    {
        var products = await _productRepository.Get(pageNumber, pageSize);
        return Result.Success<List<Product>>(products);
    }

    public async Task<Result<Product>> Update(int id, Product product)
    {
        var currentProduct = await _productRepository.Get(id);
        if (currentProduct is null)
            return Result.Failure<Product>("Product not found");

        currentProduct.Name = product.Name;
        currentProduct.Price = product.Price;

        var success = await _productRepository.Update(currentProduct);
        if (!success)
            return Result.Failure<Product>("Update failed");

        return Result.Success<Product>(currentProduct);
    }

    public async Task<Result<string>> Delete(int id)
    {
        var currentProduct = await _productRepository.Get(id);
        if (currentProduct is null)
            return Result.Failure<string>("Product not found");

        var success = await _productRepository.Delete(currentProduct);
        if (!success)
            return Result.Failure<string>("Delete failed");

        return Result.Success<string>("Ok");
    }
}
