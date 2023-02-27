using DataAccess.Entities;

namespace DataAccess.Repositories
{
    public interface IRepository<TEntity>
        where TEntity : Entity
    {
        public Task CreateAsync(TEntity entity);
        public Task UpdateAsync(TEntity entity);
        public Task<TEntity?> ReadAsync(int id);
        public Task DeleteAsync(TEntity entity);
        public Task<List<TEntity>> ListAsync();
    }
}
