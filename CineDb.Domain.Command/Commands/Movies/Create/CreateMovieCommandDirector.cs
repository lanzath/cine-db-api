namespace CineDb.Domain.Command.Commands.Movies.Create;

public sealed class CreateMovieCommandDirector
{
    public string Name { get; set; }
    public string OriginCountry { get; set; }
    public int Age { get; set; }
}