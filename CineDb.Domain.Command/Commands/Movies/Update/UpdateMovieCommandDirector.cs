namespace CineDb.Domain.Command.Movies.Update;

public sealed class UpdateMovieCommandDirector
{
    public string Name { get; set; }
    public string OriginCountry { get; set; }
    public int Age { get; set; }
}