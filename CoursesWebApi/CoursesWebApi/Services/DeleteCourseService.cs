using DataAccess.Entities;
using DataAccess.Repositories;

namespace CoursesWebApi.Services
{
    public class DeleteCourseService : IService<int, bool>
    {
        private readonly IRepository<Course> repository;

        public DeleteCourseService(IRepository<Course> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> CallAsync(int id)
        {
            var entity = await repository.ReadAsync(id);

            if (entity is null)
            {
                return false;
            }

            await repository.DeleteAsync(entity);
            
            return true;
        }
    }
}
