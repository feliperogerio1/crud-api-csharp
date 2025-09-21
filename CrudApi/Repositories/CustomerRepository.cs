using CrudApi.Interfaces.Repositories;
using CrudApi.Models.Entities;
using System.Data;

namespace CrudApi.Repositories;

public sealed class CustomerRepository : BaseRepository<int, Customer>, ICustomerRepository
{
    public CustomerRepository(IDbConnection dbConnection) : base(dbConnection) { }
}
