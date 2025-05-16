using System.Data;

using crud_api.Interfaces.IFactories;
using crud_api.Interfaces.IRepositories;
using crud_api.Utils;
using Microsoft.Data.SqlClient;

namespace crud_api.Repositories
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class, new()
    {
        private readonly IDbConnectionFactory _dbConnection;

        protected BaseRepository(IDbConnectionFactory dbConnection)
        {
            _dbConnection = dbConnection;
        }

        protected abstract string TableName { get; }

        public T? GetById(int id)
        {
            var sql = $"SELECT * FROM {TableName} WHERE Id = @Id";
            using var connection = _dbConnection.CreateConnection();
            using var command = connection.CreateCommand();
            
            command.CommandText = sql;
            var param = command.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = id;
            command.Parameters.Add(param);

            connection.Open();
            using var reader = command.ExecuteReader();
            if (!reader.Read())
            {
                return default;
            }

            return MapFromReader(reader);
        }

        public List<T> GetAll()
        {
            var sql = $"SELECT * FROM {TableName}";
            using var connection = _dbConnection.CreateConnection();
            using var command = connection.CreateCommand();
            
            command.CommandText = sql;
            var result = new List<T>();
            connection.Open();

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                 result.Add(MapFromReader(reader));
            }

            return result;
        }

        public int Add(T entity)
        {
            var properties = GetProperties(entity, includeId: false);
            var columns = string.Join(", ", properties.Keys);
            var parameters = string.Join(", ", properties.Keys.Select(k => $"@{k}"));
            var sql = $"INSERT INTO {TableName} ({columns}) OUTPUT INSERTED.Id VALUES ({parameters})";

            using var connection = _dbConnection.CreateConnection();
            using var command = connection.CreateCommand();
            command.CommandText = sql;
            BindParameters((SqlCommand)command, properties);

            connection.Open();
            var id = (int)command.ExecuteScalar();

            return id;
        }

        public void Update(T entity)
        {
            var properties = GetProperties(entity, includeId: true);
            var setClause = string.Join(", ", properties.Keys
                .Where(k => k != "Id")
                .Select(k => $"{k} = @{k}"));

            var sql = $"UPDATE {TableName} SET {setClause} WHERE Id = @Id";

            using var connection = _dbConnection.CreateConnection();
            using var command = connection.CreateCommand();
            command.CommandText = sql;
            BindParameters((SqlCommand)command, properties);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            var sql = $"DELETE FROM {TableName} WHERE Id = @Id";
            using var connection = _dbConnection.CreateConnection();
            using var command = connection.CreateCommand();
            
            command.CommandText = sql;
            var param = command.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = id;
            command.Parameters.Add(param);

            connection.Open();
            command.ExecuteNonQuery();
        }

        #region Private methods
        private static Dictionary<string, object> GetProperties(T entity, bool includeId)
        {
            return typeof(T).GetProperties()
                .Where(p => includeId || p.Name != "Id")
                .ToDictionary(p => p.Name, p => p.GetValue(entity) ?? DBNull.Value);
        }

        private static void BindParameters(SqlCommand command, Dictionary<string, object> values)
        {
            foreach (var (key, value) in values)
            {
                command.Parameters.AddWithValue($"@{key}", value);
            }
        }

        private static T MapFromReader(IDataReader reader)
        {
            var obj = new T();
            foreach (var prop in typeof(T).GetProperties())
            {
                if (reader.HasColumn(prop.Name) && reader[prop.Name] != DBNull.Value)
                {
                    prop.SetValue(obj, reader[prop.Name]);
                }
            }

            return obj;
        }
        #endregion
    }
}
