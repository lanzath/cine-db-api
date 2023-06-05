using MediatR;

namespace CineDb.Domain.Command.Commands.Movies.Delete;

public sealed class DeleteMovieCommand : IRequest<Unit>
{
    public int Id { get; set; }

    public DeleteMovieCommand(int id) => Id = id;
}