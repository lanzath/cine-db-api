namespace CineDb.Domain.Contracts;

// TODO: Create concrete implementation
public interface IUnitOfWork
{
    Task SaveChangesAsync();
}