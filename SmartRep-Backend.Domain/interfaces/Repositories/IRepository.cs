﻿using System.Linq.Expressions;

namespace SmartRep_Backend.Domain.interfaces.Repositories;
public interface IRepository<TEntity>
    where TEntity : IEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
    Task<TEntity?> GetByIdAsync(Guid Id, CancellationToken cancellationToken);
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity?> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
    Task<int> GetCountAsync(CancellationToken cancellationToken);
}