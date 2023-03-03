
using Library_API.Entities;
using Library_API.Models;
using Library_API.Repositories;
using Library_API.Services;
using Microsoft.EntityFrameworkCore;

namespace Library_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connectionString = builder.Configuration.GetConnectionString("Dev");

            builder.Services.AddDbContext<LibraryDbContext>(
                options => options.UseSqlServer(connectionString)
            );

            builder.Services.AddScoped<IService<CreateBookRequest, BookModel>, CreateBookService>();
            builder.Services.AddScoped<IService<int, UpdateBookStatusResponse>, UpdateBookStatusService>();
            builder.Services.AddScoped<IService<UpdateBookRequest, BookModel>, UpdateBookService>();
            builder.Services.AddScoped<IService<int, BookModel>, GetBookService>();
            builder.Services.AddScoped<IService<int, List<BookModel>>, ListBooksService>();
            builder.Services.AddScoped<IService<int, bool>, DeleteBookService>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}