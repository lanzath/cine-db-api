namespace CineDb.Domain.Entities;

public class Director : Entity<Guid>
{
    public string Name { get; private set; }
    public string OriginCountry { get; private set; }
    public int Age { get; private set; }
    public virtual ICollection<Movie> Movies { get; private set; }

    public Director(Guid id, string originCountry, int age)
    {
        Id = id;
        OriginCountry = originCountry;
        Age = age;
    }

    private Director()
    { }
}