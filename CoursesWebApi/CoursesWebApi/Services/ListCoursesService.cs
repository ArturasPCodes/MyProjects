using CoursesWebApi.Models;
using DataAccess.Entities;
using DataAccess.Repositories;

namespace CoursesWebApi.Services
{
    public class ListCoursesService : IService<List<CourseModel>>
    {
        private readonly IRepository<Course> repository;

        public ListCoursesService(IRepository<Course> repository)
        {
            this.repository = repository;
        }

        public async Task<List<CourseModel>> CallAsync()
        {
            var entities = await repository.ListAsync();

            return entities
                .Select(
                    entity => 
                        new CourseModel(
                            entity.Id,
                            entity.Title,
                            entity.Description,
                            (double)entity.Price,
                            entity.Hours
                        )
                )
                .ToList();
        }
    }
}
