using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Entities
{
    public class SongDbContextFactory : IDesignTimeDbContextFactory<SongDbContext>
    {
        public SongDbContext CreateDbContext(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args).Build();

            IConfiguration config = host.Services.GetRequiredService<IConfiguration>();

            var connectionString = config.GetValue<string>("ConnectionStrings:Local");

            var optionsBuilder = new DbContextOptionsBuilder<SongDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new SongDbContext(optionsBuilder.Options);
        }
    }
}
