using CrudApi.Models.Entities;
using CrudApi.Utils;

namespace CrudApi.Interfaces.Services;

public interface IProductService
{
    Task<Result<Product>> Insert(Product product);

    Task<Result<Product>> Get(int id);

    Task<Result<List<Product>>> Get(int pageNumber, int pageSize);

    Task<Result<Product>> Update(int id, Product product);

    Task<Result<string>> Delete(int id);
}
