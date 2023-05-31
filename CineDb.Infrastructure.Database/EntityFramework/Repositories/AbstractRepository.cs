using CineDb.Domain.Contracts;
using CineDb.Domain.Entities;

namespace CineDb.Infrastructure.Database.EntityFramework.Repositories;

public abstract class AbstractRepository<TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId> where TId : struct
{
    // TODO: Delegate Commit (SaveChangesAsync) to UnitOfWork.

    private readonly AppDbContext _context;

    public AbstractRepository(AppDbContext context) => _context = context;

    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    // This method will be invoked only to retrieve existing records, for update purposes.
    public virtual async Task<TEntity> GetByIdAsync(TId id)
    {
       return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task RemoveAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }
}