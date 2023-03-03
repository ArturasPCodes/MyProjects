using Library_API.Entities;

namespace Library_API.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        public Task CreateAsync(T entity);

        public Task UpdateAsync(T entity);

        public Task<T?> ReadAsync(int id);

        public Task DeleteAsync(T entity);

        public Task<List<T>> ListAsync();
    }
}
