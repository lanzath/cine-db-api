using CineDb.Domain.Entities;
using MediatR;

namespace CineDb.Domain.Query.Queries.Find.Movies;

public sealed class FindMoviesQueryHandler : IRequestHandler<FindMoviesQuery, ICollection<Movie>>
{
    // TODO: Implement readonly repository with SQL and Dapper
    public Task<ICollection<Movie>> Handle(FindMoviesQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}