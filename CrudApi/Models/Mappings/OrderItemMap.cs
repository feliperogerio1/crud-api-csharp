using CrudApi.Models.Entities;
using Dapper.FluentMap.Dommel.Mapping;

namespace CrudApi.Models.Mappings;

public class OrderItemMap : DommelEntityMap<OrderItem>
{
    public OrderItemMap()
    {
        ToTable("order_item");
        Map(o => o.OrderId).ToColumn("OrderId").IsKey();
        Map(o => o.ProductId).ToColumn("ProductId").IsKey();
        Map(o => o.Quantity).ToColumn("Quantity");
        Map(o => o.SubTotal).ToColumn("SubTotal");
    }
}
