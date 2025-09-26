using CrudApi.Models.Entities;

namespace CrudApi.Interfaces.Repositories;

public interface IOrderRepository : IRepository<int, Order>
{
    Task<Order?> GetWithCustomer(int id);
}
