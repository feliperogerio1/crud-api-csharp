using CrudApi.Interfaces.Repositories;
using CrudApi.Models.Entities;
using Dommel;
using System.Data;

namespace CrudApi.Repositories;

public sealed class OrderRepository : BaseRepository<int, Order>, IOrderRepository
{
    public OrderRepository(IDbConnection dbConnection) : base(dbConnection) { }

    public async Task<Order?> GetWithItems(int id)
    {
        var order = await _dbConnection.GetAsync<Order, Customer, OrderItem, Order>(id);
        return order;
    }

    public async Task InsertItems(IEnumerable<OrderItem> orderItems)
    {
        await _dbConnection.InsertAllAsync(orderItems);
    }

    public async Task DeleteItems(int id)
    {
        await _dbConnection.DeleteMultipleAsync<OrderItem>(o => o.OrderId == id);
    }
}
