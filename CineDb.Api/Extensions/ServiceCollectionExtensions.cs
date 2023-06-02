using System.Reflection;
using System.Text.Json.Serialization;
using CineDb.Domain.Command.Mappers;
using CineDb.Domain.Command.Commands.Movies.Create;
using CineDb.Domain.Contracts;
using CineDb.Domain.Query.Queries.Movies.GetById;
using CineDb.Infrastructure.Database.EntityFramework;
using CineDb.Infrastructure.Database.EntityFramework.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace CineDb.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
        });

        services.AddTransient<IMovieRepository, MovieRepository>();

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlite("Data Source=../CineDb.Infrastructure.Database/Database.sqlite");
        });
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(typeof(CreateMovieCommand).Assembly, typeof(GetMovieByIdQuery).Assembly));

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