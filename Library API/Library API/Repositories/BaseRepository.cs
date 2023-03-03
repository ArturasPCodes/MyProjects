using Library_API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library_API.Repositories
{
    public class BaseRepository<T> : IRepository<T>
        where T : Entity
    {
        protected LibraryDbContext LibraryDbContext;
        protected DbSet<T> Entities;

        public BaseRepository(LibraryDbContext libraryDbContext)
        {
            LibraryDbContext = libraryDbContext;
            Entities = LibraryDbContext.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            await LibraryDbContext.AddAsync(entity);
            await LibraryDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            Entities.Remove(entity);
            await LibraryDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> ListAsync()
        {
            return await Entities.ToListAsync();
        }

        public async Task<T?> ReadAsync(int id)
        {
            return await Entities
                .FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            LibraryDbContext.Update(entity);
            await LibraryDbContext.SaveChangesAsync();
        }
    }
}
