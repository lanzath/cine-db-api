using CineDb.Domain.Enums;
using MediatR;
using Newtonsoft.Json;

namespace CineDb.Domain.Command.Movies.Update;

public sealed class UpdateMovieCommand : IRequest<Unit>
{
    [JsonIgnore]
    public int Id { get; set; }
    [JsonIgnore]
    public int DirectorId { get; set; }
    public string Title { get; set; }
    public Genre Genre { get; set; }
    public ushort Year { get; set; }
    public UpdateMovieCommandDirector Director { get; set; }
}