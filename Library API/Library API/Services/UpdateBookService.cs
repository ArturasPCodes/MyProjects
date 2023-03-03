using Library_API.Entities;
using Library_API.Models;
using Library_API.Repositories;

namespace Library_API.Services
{
    public class UpdateBookService : IService<UpdateBookRequest, BookModel>
    {
        private readonly IRepository<Book> repository;

        public UpdateBookService(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        public async Task<BookModel> CallAsync(UpdateBookRequest request)
        {
            if (request.Id is 0)
                throw new ArgumentNullException(nameof(request.Id));

            var entity = await repository.ReadAsync(request.Id);

            entity.Title = request.Title;
            entity.Author = request.Author;
            entity.PageCount = request.PageCount;
            entity.IsRead = request.IsRead;

            await repository.UpdateAsync(entity);

            return new BookModel(
                entity.Id,
                entity.Title,
                entity.Author,
                entity.PageCount,
                entity.IsRead
            );
        }
    }
}
