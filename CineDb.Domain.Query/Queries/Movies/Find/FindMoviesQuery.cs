using CineDb.Domain.Entities;
using MediatR;

namespace CineDb.Domain.Query.Queries.Find.Movies;

public sealed class FindMoviesQuery : IRequest<ICollection<Movie>>
{ }