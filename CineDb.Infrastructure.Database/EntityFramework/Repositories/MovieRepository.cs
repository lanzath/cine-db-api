using CineDb.Domain.Contracts;
using CineDb.Domain.Entities;

namespace CineDb.Infrastructure.Database.EntityFramework.Repositories;

public sealed class MovieRepository : AbstractRepository<Movie, int>, IMovieRepository
{
    public MovieRepository(AppDbContext context) : base(context)
    { }
}