namespace WebShop.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetElementAsync(int id);
        Task<IEnumerable<T>> GetRangeAsync(int start, int end);
        void Create(T item);
        void Update(T item);
        void Delete(T item);
        Task SaveAsync();

    }
}
