using Library_API.Entities;
using Library_API.Models;
using Library_API.Repositories;

namespace Library_API.Services
{
    public class GetBookService : IService<int, BookModel>
    {
        private readonly IRepository<Book> repository;

        public GetBookService(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        public async Task<BookModel> CallAsync(int id)
        {
            var entity = await repository.ReadAsync(id);

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
