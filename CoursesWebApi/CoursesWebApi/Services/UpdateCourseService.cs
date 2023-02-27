using CoursesWebApi.Models;
using DataAccess.Entities;
using DataAccess.Repositories;

namespace CoursesWebApi.Services
{
    public class UpdateCourseService : IService<UpdateCourseRequest, CourseModel>
    {
        private IRepository<Course> repository;

        public UpdateCourseService(IRepository<Course> repository)
        {
            this.repository = repository;
        }

        public async Task<CourseModel> CallAsync(UpdateCourseRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = await repository.ReadAsync(request.Id);

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Price = (decimal)request.Price;
            entity.Hours = request.Hours;

            await repository.UpdateAsync(entity);

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
