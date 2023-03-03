using Library_API.Entities;
using Library_API.Models;
using Library_API.Repositories;

namespace Library_API.Services
{
    public class CreateBookService : IService<CreateBookRequest, BookModel>
    {
        private readonly IRepository<Book> repository;

        public CreateBookService(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        public async Task<BookModel> CallAsync(CreateBookRequest request)
        {
            var bookEntity = new Book
            {
                Title = request.Title,
                Author = request.Author,
                PageCount = request.PageCount,
                IsRead= request.IsRead,
            };

            await repository.CreateAsync(bookEntity);

            return new BookModel(
                bookEntity.Id,
                bookEntity.Title,
                bookEntity.Author,
                bookEntity.PageCount,
                bookEntity.IsRead
            );
        }
    }
}
