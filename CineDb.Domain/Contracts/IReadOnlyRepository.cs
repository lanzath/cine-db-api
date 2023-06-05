using CineDb.Domain.Entities;

namespace CineDb.Domain.Contracts;

public interface IReadOnlyRepository<TEntity, TId>
    where TEntity : Entity<TId> where TId : struct
{
    Task<TEntity> GetByIdAsync(TId id);
}
