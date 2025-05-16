using System.Data;

namespace crud_api.Interfaces.IFactories
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
