using CoursesWebApi.Models;
using DataAccess.Entities;
using DataAccess.Repositories;

namespace CoursesWebApi.Services
{
    public class CreateCourseService : IService<CreateCourseRequest, CourseModel>
    {
        private readonly IRepository<Course> repository;

        public CreateCourseService(IRepository<Course> repository)
        {
            this.repository = repository;
        }

        public async Task<CourseModel> CallAsync(CreateCourseRequest request)
        {
            var courseEntity = new Course
            {
                Title = request.Title,
                Description = request.Description,
                Price = (decimal)request.Price,
                Hours = request.Hours
            };

            await repository.CreateAsync(courseEntity);

            return new CourseModel(
                courseEntity.Id,
                courseEntity.Title,
                courseEntity.Description,
                (double)courseEntity.Price,
                courseEntity.Hours
            );
        }
    }
}
