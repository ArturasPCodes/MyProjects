
using CoursesWebApi.Models;
using CoursesWebApi.Services;
using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CoursesWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("Prod");

            builder.Services.AddDbContext<CoursesDbContext>(
                options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IService<CreateCourseRequest, CourseModel>, CreateCourseService>();
            builder.Services.AddScoped<IService<UpdateCourseRequest, CourseModel>, UpdateCourseService>();
            builder.Services.AddScoped<IService<int, CourseModel>, GetCourseService>();
            builder.Services.AddScoped<IService<List<CourseModel>>, ListCoursesService>();
            builder.Services.AddScoped<IService<int, bool>, DeleteCourseService>();
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