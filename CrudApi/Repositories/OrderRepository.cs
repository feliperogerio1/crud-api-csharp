using CrudApi.Interfaces.Repositories;
using CrudApi.Models.Entities;
using Dommel;
using System.Data;

namespace CrudApi.Repositories;

public sealed class OrderRepository : BaseRepository<int, Order>, IOrderRepository
{
    public OrderRepository(IDbConnection dbConnection) : base(dbConnection) { }

    public async Task<Order?> GetWithCustomer(int id)
    {
        var order = await _dbConnection.GetAsync<Order, Customer, Order>(id);
        return order;
    }
}
