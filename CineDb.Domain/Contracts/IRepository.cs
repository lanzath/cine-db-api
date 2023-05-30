using CineDb.Domain.Entities;

namespace CineDb.Domain.Contracts;

public interface IRepository<TEntity, TId>
    where TEntity : Entity<TId> where TId : struct
{
    Task AddAsync(TEntity entity);
    Task RemoveAsync(TEntity id);
    Task UpdateAsync(TEntity entity);
    Task<TEntity?> GetByIdAsync(TId id);
}