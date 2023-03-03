using Library_API.Entities;
using Library_API.Repositories;

namespace Library_API.Services
{
    public class DeleteBookService : IService<int, bool>
    {
        private readonly IRepository<Book> repository;

        public DeleteBookService(IRepository<Book> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> CallAsync(int id)
        {
            var entity = await repository.ReadAsync(id);

            if (entity is null)
                return false;

            await repository.DeleteAsync(entity);

            return true;
        }
    }
}
