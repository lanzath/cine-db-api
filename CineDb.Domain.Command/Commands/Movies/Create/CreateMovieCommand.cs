using CineDb.Domain.Enums;
using MediatR;

namespace CineDb.Domain.Command.Movies.Create;

public sealed class CreateMovieCommand : IRequest<Unit>
{
    //TODO: Validate with fluent validator
    public string Title { get; set; }
    public Genre Genre { get; set; }
    public ushort Year { get; set; }
    public CreateMovieCommandDirector Director { get; set; }
}