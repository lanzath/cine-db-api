using CineDb.Domain.Enums;
using MediatR;

namespace CineDb.Domain.Command.Movies.Update;

public sealed class UpdateMovieCommand : IRequest<Unit>
{
    public string Title { get; set; }
    public Genre Genre { get; set; }
    public ushort Year { get; set; }
    public UpdateMovieCommandDirector Director { get; set; }
}