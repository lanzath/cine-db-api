using Newtonsoft.Json;

namespace CineDb.Domain.Command.Movies.Update;

public sealed class UpdateMovieCommandDirector
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; }
    public string OriginCountry { get; set; }
    public int Age { get; set; }
}