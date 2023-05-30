using CineDb.Domain.Command.Mappers;
using CineDb.Domain.Command.Movies.Create;
using CineDb.Domain.Contracts;
using CineDb.Infrastructure.Database.EntityFramework;
using CineDb.Infrastructure.Database.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CineDb.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddTransient<IMovieRepository, MovieRepository>();
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite("Data Source=../CineDb.Infrastructure.Database/Database.sqlite");
        });
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateMovieCommand).Assembly));
        services.AddAutoMapper(cfg =>
        {
            cfg.AddProfile<MovieProfile>();
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
}