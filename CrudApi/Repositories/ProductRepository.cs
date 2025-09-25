using CrudApi.Interfaces.Repositories;
using CrudApi.Models.Entities;
using System.Data;

namespace CrudApi.Repositories;

public sealed class ProductRepository : BaseRepository<int, Product>, IProductRepository
{
    public ProductRepository(IDbConnection dbConnection) : base(dbConnection) { }
}
