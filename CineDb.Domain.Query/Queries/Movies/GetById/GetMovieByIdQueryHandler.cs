using CineDb.Domain.Contracts;
using CineDb.Domain.Entities;
using MediatR;

namespace CineDb.Domain.Query.Queries.Movies.GetById;

public sealed class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, Movie>
{
    private readonly IMovieReadOnlyRepository _movieRepository;

    public GetMovieByIdQueryHandler(IMovieReadOnlyRepository movieRepository) => _movieRepository = movieRepository;

    public async Task<Movie> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
    {
        return await _movieRepository.GetByIdAsync(request.Id);
    }
}