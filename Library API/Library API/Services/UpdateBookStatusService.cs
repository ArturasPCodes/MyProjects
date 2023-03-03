using Library_API.Entities;
using Library_API.Models;
using Library_API.Repositories;

namespace Library_API.Services
{
    public class UpdateBookStatusService : IService<int, UpdateBookStatusResponse>
    {
        private readonly IRepository<Book> repository;

        public UpdateBookStatusService(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        public async Task<UpdateBookStatusResponse> CallAsync(int id)
        {
            if (id is 0)
                throw new ArgumentNullException(nameof(id));

            var entity = await repository.ReadAsync(id);

            entity.IsRead = entity.IsRead ? false : true;

            await repository.UpdateAsync(entity);

            return new UpdateBookStatusResponse(
                entity.Id,
                entity.Title,
                entity.Author,
                entity.PageCount,
                entity.IsRead
            );
        }
    }
}
