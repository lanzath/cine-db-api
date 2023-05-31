using CineDb.Domain.Contracts;
using CineDb.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CineDb.Infrastructure.Database.EntityFramework.Repositories;

public sealed class MovieRepository : AbstractRepository<Movie, int>, IMovieRepository
{
    private readonly AppDbContext _context;

    public MovieRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async override Task<Movie> GetByIdAsync(int id)
    {
        return await _context.Set<Movie>()
            .Include(p => p.Director)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}