using Microsoft.EntityFrameworkCore;
using SmartRep_Backend.Domain.interfaces.Repositories;
using SmartRep_Backend.Domain.interfaces;
using System.Linq.Expressions;
using SmartRep_Backend.Infrastructure.Data;

namespace SmartRep_Backend.Infrastructure.Repositories;
public class BaseRepository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
{
    protected readonly SmartRepDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(SmartRepDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(Guid Id, CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking().FirstAsync(entity => entity.Id == Id, cancellationToken);
    }

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
    }
    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        _context.Entry(entity).State = EntityState.Modified;
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await _dbSet.AsNoTracking().FirstOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<int> GetCountAsync(CancellationToken cancellationToken)
    {
        return await _dbSet.CountAsync(cancellationToken);
    }
}