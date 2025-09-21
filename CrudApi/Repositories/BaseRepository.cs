using CrudApi.Interfaces.Repositories;
using Dommel;
using System.Data;
using System.Linq.Expressions;

namespace CrudApi.Repositories;

public abstract class BaseRepository<TKey, TEntity> : IRepository<TKey, TEntity> 
    where TKey : notnull where TEntity : class
{
    protected readonly IDbConnection _dbConnection;

    protected BaseRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<TKey> Insert(TEntity entity)
    {
        var key = await _dbConnection.InsertAsync(entity);
        return (TKey)Convert.ChangeType(key, typeof(TKey));
    }

    public async Task<TEntity?> Get(TKey key)
    {
        var entity = await _dbConnection.GetAsync<TEntity>(key);
        return entity;
    }

    public async Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate)
    {
        var entities = await _dbConnection.SelectAsync(predicate);
        return entities.ToList();
    }

    public async Task<List<TEntity>> Get(int pageNumber, int pageSize)
    {
        var entities = await _dbConnection.GetPagedAsync<TEntity>(pageNumber, pageSize);
        return entities.ToList();
    }

    public async Task<bool> Update(TEntity entity)
    {
        var success = await _dbConnection.UpdateAsync(entity);
        return success;
    }

    public async Task<bool> Delete(TEntity entity)
    {
        var success = await _dbConnection.DeleteAsync(entity);
        return success;
    }
}
