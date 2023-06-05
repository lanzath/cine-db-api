using CineDb.Domain.Contracts;
using CineDb.Domain.Entities;
using Dapper;

namespace CineDb.Infrastructure.Database.Dapper.Repositories;

public sealed class MovieReadOnlyRepository : IMovieReadOnlyRepository
{
    private readonly IDapperContext _context;

    public MovieReadOnlyRepository(IDapperContext context) => _context = context;

    public async Task<Movie> GetByIdAsync(int id)
    {
        using var connection = _context.GetConnection();

        var builder = new SqlBuilder();

        var query = builder.AddTemplate(@"
            SELECT
                M.Id,
                M.Title,
                M.Genre,
                M.Year,
                M.DirectorId,
                D.Id,
                D.Name,
                D.Age,
                D.OriginCountry
            FROM Movie AS M
            INNER JOIN Director D ON M.DirectorId = D.Id
            WHERE M.Id = @id", new { id });

        var result = await connection.QueryAsync<Movie, Director, Movie>(
            query.RawSql,
            (movie, director) =>
            {
                movie.SetDirector(director);
                return movie;
            },
            query.Parameters
        );

        return result.FirstOrDefault();
    }
}
