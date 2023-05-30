using CineDb.Domain.Enums;

namespace CineDb.Domain.Entities;

public class Movie : Entity<int>
{
    public string Title { get; private set; }
    public ushort Year { get; private set; }
    public Genre Genre { get; private set; }
    public Guid DirectorId { get; private set; }
    public virtual Director Director { get; private set; }

    public Movie(int id, string title, ushort year, Genre genre)
    {
        Id = id;
        Title = title;
        Year = year;
        Genre = genre;
        DirectorId = Guid.NewGuid();
    }

    private Movie()
    { }
}