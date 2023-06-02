using CineDb.Domain.Contracts;
using MediatR;

namespace CineDb.Domain.Command.Commands.Movies.Delete;

public sealed class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand, Unit>
{
    private readonly IMovieRepository _movieRepository;

    public DeleteMovieCommandHandler(IMovieRepository movieRepository) => _movieRepository = movieRepository;

    public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await _movieRepository.GetByIdAsync(request.Id);

        await _movieRepository.RemoveAsync(movie);

        return Unit.Value;
    }
}