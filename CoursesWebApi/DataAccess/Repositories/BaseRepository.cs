
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> //implementing interface
        where TEntity : Entity 
    {
        protected CoursesDbContext CourseDbContext; 
        protected DbSet<TEntity> Entities;

        public BaseRepository(CoursesDbContext courseDbContext)
        { 
            CourseDbContext = courseDbContext;
            Entities = CourseDbContext.Set<TEntity>(); 
        }

        public async Task CreateAsync(TEntity entity)
        {
            await CourseDbContext.AddAsync(entity);
            await CourseDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            CourseDbContext.Update(entity);
            await CourseDbContext.SaveChangesAsync();
        }


        public async Task<TEntity?> ReadAsync(int id)
        {
            return await Entities
                .FirstOrDefaultAsync(entity => entity.Id == id);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Entities.Remove(entity);
            await CourseDbContext.SaveChangesAsync();
        }

        public async Task<List<TEntity>> ListAsync()
        {
            return await Entities.ToListAsync();
        }
    }
}
