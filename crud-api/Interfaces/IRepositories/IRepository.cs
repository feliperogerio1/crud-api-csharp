namespace crud_api.Interfaces.IRepositories
{
    public interface IRepository<T>
    {
        T? GetById(int id);
        List<T> GetAll();
        int Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
