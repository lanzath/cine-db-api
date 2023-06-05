using CineDb.Domain.Enums;
using MediatR;

namespace CineDb.Domain.Command.Commands.Movies.Create;

public sealed class CreateMovieCommand : IRequest<Unit>
{
    public string Title { get; set; }
    public Genre Genre { get; set; }
    public ushort Year { get; set; }
    public CreateMovieCommandDirector Director { get; set; }
}