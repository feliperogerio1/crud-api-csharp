using CrudApi.Models.Entities;
using Dapper.FluentMap.Dommel.Mapping;

namespace CrudApi.Models.Mappings;

public class CustomerMap : DommelEntityMap<Customer>
{
    public CustomerMap()
    {
        ToTable("customer");
        Map(c => c.Id).ToColumn("Id").IsIdentity().IsKey();
        Map(c => c.Name).ToColumn("Name");
    }
}
