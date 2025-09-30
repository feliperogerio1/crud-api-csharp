using CrudApi.Models.Entities;

namespace CrudApi.Interfaces.Repositories;

public interface IOrderRepository : IRepository<int, Order>
{
    Task<Order?> GetWithItems(int id);

    #region OrderItem
    Task InsertItems(IEnumerable<OrderItem> items);

    Task DeleteItems(int OrderId);
    #endregion
}
