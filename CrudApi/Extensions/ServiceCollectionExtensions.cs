using Microsoft.Data.SqlClient;
using System.Data;

namespace CrudApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSqlDatabase(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        if (string.IsNullOrEmpty(connectionString))
            return services;

        services.AddTransient<IDbConnection>(provider => new SqlConnection(connectionString));
        return services;
    }
}
