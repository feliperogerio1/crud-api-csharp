using System.Linq.Expressions;

namespace CrudApi.Interfaces.Repositories;

public interface IRepository<TKey, TEntity>
{
    Task<TKey> Insert(TEntity entity);

    Task<TEntity?> Get(TKey key);

    Task<List<TEntity>> Get(Expression<Func<TEntity, bool>> predicate);

    Task<List<TEntity>> Get(int pageNumber, int pageSize);

    Task<bool> Update(TEntity entity);

    Task<bool> Delete(TEntity entity);
}
