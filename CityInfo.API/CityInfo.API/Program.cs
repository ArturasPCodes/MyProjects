using CityInfo.API.DbContexts;
using CityInfo.API.Services;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using System.Text;

namespace CityInfo.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs/cityinfo.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog();

            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                //Returns a status saying that request format is not supporte
                options.ReturnHttpNotAcceptable = true;
            }).AddNewtonsoftJson() //For partial updated required to add newtonsoft Json
           .AddXmlDataContractSerializerFormatters();  //For support of XML data format

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // Adding XML documentation
            builder.Services.AddSwaggerGen(setupAction =>
            {
                var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                setupAction.IncludeXmlComments(xmlCommentsFullPath);

                // for API documentation
                setupAction.AddSecurityDefinition("CityInfoApiBearerAuth", new OpenApiSecurityScheme()
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    Description = "Input a valid token to access this API"
                });

                // making sure security is required
                setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "CityInfoApiBearerAuth" }
                        }, new List<string>() }
                });
            });


            builder.Services.AddSingleton<FileExtensionContentTypeProvider>(); //registering allows to inject elsewhere to get different formats of files 

            //Register services
            #if DEBUG
            builder.Services.AddTransient<IMailService, LocalMailService>();
#else
            builder.Services.AddTransient<IMailService,CloudMailService>();
#endif

            builder.Services.AddSingleton<CitiesDataStore>();

            // Adding db context
            builder.Services.AddDbContext<CityInfoContext>(
                dbContextOptions => dbContextOptions.UseSqlite(
                    builder.Configuration["ConnectionStrings:CityInfoDBConnectionString"]));

            builder.Services.AddScoped<ICityInfoRepository, CityInfoRepository>();

            // Adding mapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Adding authentication
            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new()
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateIssuerSigningKey = true,
                            ValidIssuer = builder.Configuration["Authentication:Issuer"],
                            ValidAudience = builder.Configuration["Authentication:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(
                                Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
                        };
                    }
                );

            // Creating and adding policy
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("MustBeFromAntwerp", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("city", "Antwerp");
                });
            });

            // Versioning
            builder.Services.AddApiVersioning(setupAction =>
            {
                setupAction.AssumeDefaultVersionWhenUnspecified = true;
                setupAction.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                setupAction.ReportApiVersions = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.MapControllers(); using useRouting and useEndpoints instead

            app.Run();
        }
    }
}