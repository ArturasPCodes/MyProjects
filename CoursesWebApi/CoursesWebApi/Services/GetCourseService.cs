using CoursesWebApi.Models;
using DataAccess.Entities;
using DataAccess.Repositories;

namespace CoursesWebApi.Services
{
    public class GetCourseService : IService<int, CourseModel>
    {
        private IRepository<Course> repository;

        public GetCourseService(IRepository<Course> repository)
        {
            this.repository = repository;
        }

        public async Task<CourseModel> CallAsync(int id)
        {
            var entity = await repository.ReadAsync(id);

            return new CourseModel(
                entity.Id,
                entity.Title,
                entity.Description,
                (double)entity.Price,
                entity.Hours
            );
        }
    }
}
