using CineDb.Domain.Entities;

namespace CineDb.Domain.Contracts;

public interface IMovieReadOnlyRepository : IReadOnlyRepository<Movie, int>
{ }