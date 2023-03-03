using Library_API.Entities;

namespace Library_API.Repositories
{
    public class BookRepository : BaseRepository<Book>
    {
        public BookRepository(LibraryDbContext libraryDbContext)
            : base(libraryDbContext)
        {
        }
    }
}
