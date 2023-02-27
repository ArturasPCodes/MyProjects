using Microsoft.EntityFrameworkCore;

namespace DataAccess.Entities
{
    public class SongDbContext : DbContext
    {
        public SongDbContext(DbContextOptions<SongDbContext> options)
            : base(options)
        {
        }
        public DbSet<SongDataEntity> SongsData { get; set; }
    }
}
