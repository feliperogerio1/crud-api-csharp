using CrudApi.Models.Entities;
using Dapper.FluentMap.Dommel.Mapping;

namespace CrudApi.Models.Mappings;

public class ProductMap : DommelEntityMap<Product>
{
    public ProductMap()
    {
        ToTable("product");
        Map(p => p.Id).ToColumn("Id").IsIdentity().IsKey();
        Map(p => p.Name).ToColumn("Name");
        Map(p => p.Price).ToColumn("Price");
    }
}
