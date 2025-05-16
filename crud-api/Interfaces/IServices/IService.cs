using crud_api.Utils;

namespace crud_api.Interfaces.IServices
{
    public interface IService<T>
    {
        Task<Result<T>> Insert(T entity);

        Task<Result<List<T>>> Get();

        Task<Result<T?>> Get(int id);

        Task<Result<T>> Update(int id, T entity);

        Task<Result<string>> Delete(int id);
    }
}
