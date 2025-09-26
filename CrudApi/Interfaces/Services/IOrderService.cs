using CrudApi.Models.Entities;
using CrudApi.Utils;

namespace CrudApi.Interfaces.Services;

public interface IOrderService
{
    Task<Result<Order>> Insert(Order order);

    Task<Result<Order>> Get(int id);

    Task<Result<List<Order>>> Get(int pageNumber, int pageSize);

    Task<Result<Order>> GetWithCustomer(int id);

    Task<Result<Order>> Update(int id, Order order);

    Task<Result<string>> Delete(int id);
}
