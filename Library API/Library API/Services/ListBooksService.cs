using Library_API.Entities;
using Library_API.Models;
using Library_API.Repositories;

namespace Library_API.Services
{
    public class ListBooksService : IService<int, List<BookModel>>
    {
        private readonly IRepository<Book> repository;

        public ListBooksService(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        public async Task<List<BookModel>> CallAsync(int limit)
        {
            var entities = await repository.ListAsync();

            return entities
                .Select(
                    entity => new BookModel(
                        entity.Id,
                        entity.Title,
                        entity.Author,
                        entity.PageCount,
                        entity.IsRead
                    )
                )
                .Take(limit)
                .ToList();
        }
    }
}
