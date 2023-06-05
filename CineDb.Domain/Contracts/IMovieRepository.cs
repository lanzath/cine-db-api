using CineDb.Domain.Entities;

namespace CineDb.Domain.Contracts;

public interface IMovieRepository : IRepository<Movie, int>
{ }