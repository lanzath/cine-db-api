namespace CineDb.Domain.Entities;

public abstract class Entity<TId> where TId : struct
{
    public TId Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
}