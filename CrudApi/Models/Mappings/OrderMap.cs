using CrudApi.Models.Entities;
using Dapper.FluentMap.Dommel.Mapping;

namespace CrudApi.Models.Mappings;

public class OrderMap : DommelEntityMap<Order>
{
    public OrderMap()
    {
        ToTable("order");
        Map(o => o.Id).ToColumn("Id").IsIdentity().IsKey();
        Map(o => o.OrderDate).ToColumn("OrderDate");
        Map(o => o.Total).ToColumn("Total");
        Map(o => o.CustomerId).ToColumn("CustomerId");
    }
}
