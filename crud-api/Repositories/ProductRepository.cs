using crud_api.Interfaces.IFactories;
using crud_api.Interfaces.IRepositories;
using crud_api.Models.Entities;

namespace crud_api.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(IDbConnectionFactory dbConnection) : base(dbConnection) { }

        protected override string TableName => "product";
    }
}
