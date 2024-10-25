using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;
using Semaphore = API.Entities.Semaphore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, 
        IConfiguration config)
    {
        string[] allowedOrigins = new string[] {"http://localhost:4200"};
        
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin() //.WithOrigins(allowedOrigins)
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

        // services.AddDbContext<DataContex>(opt => {
        //     opt.UseSqlite(config.GetConnectionString("DefaultConnectionSQLite"));
        // } );

        services.AddDbContext<DataContex>(opt => {
            opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        } );

        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<ILogApi, LogApi>();

        // Repositorys
        services.AddScoped<IUserRepositoy, UserRepository>();
        services.AddScoped<IDocRepository, DocRepository>();
        services.AddScoped<ISpesimenRepository, SpesimenRepository>();
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IUnitRepository, UnitRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IPointRepository, PointRepository>();
        services.AddScoped<ISemaphoreRepository, SemaphoreRepository>();
        services.AddScoped<IQualityStandardRepository, QualityStandardRepository>();

        // AutoMappers
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


        return services;
    }
}
