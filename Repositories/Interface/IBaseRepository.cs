namespace VoteApp.Repositories.Interface
{
    public interface IBaseRepository<T>
    {
        Task<T> Add(T entity);
        T Update (T entity);
        Task<int> Save();
    }
}
