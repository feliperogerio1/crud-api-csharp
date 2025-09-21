using CrudApi.Models.Entities;
using CrudApi.Utils;

namespace CrudApi.Interfaces.Services;

public interface ICustomerService
{
    Task<Result<Customer>> Insert(Customer customer);

    Task<Result<Customer>> Get(int id);

    Task<Result<List<Customer>>> Get(int pageNumber, int pageSize);

    Task<Result<Customer>> Update(int id, Customer customer);

    Task<Result<string>> Delete(int id);
}
