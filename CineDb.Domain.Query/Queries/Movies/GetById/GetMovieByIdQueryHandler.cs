using CineDb.Domain.Contracts;
using CineDb.Domain.Entities;
using MediatR;

namespace CineDb.Domain.Query.Queries.Movies.GetById;

public sealed class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, Movie>
{
    private readonly IMovieRepository _movieRepository;

    public GetMovieByIdQueryHandler(IMovieRepository movieRepository) => _movieRepository = movieRepository;

    // TODO: Implement readonly repository with SQL and Dapper
    public async Task<Movie> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        return await _movieRepository.GetByIdAsync(request.Id);
    }
}