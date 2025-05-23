using Microsoft.EntityFrameworkCore;
using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;
using SmartRep_Backend.Domain.interfaces.Repositories;
using SmartRep_Backend.Infrastructure.Data;
using SmartRep_Backend.Infrastructure.Extentions.IncludeStateExtentions;
using System.Linq.Expressions;

namespace SmartRep_Backend.Infrastructure.Repositories;
public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
{
    public NotificationRepository(SmartRepDbContext context) : base(context) { }

    public async Task<IEnumerable<Notification>> GetWithIncludeAsync(
        NotificationIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .IncludeWithState(includeState)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Notification>> GetWithIncludeByPredicateAsync(
        Expression<Func<Notification, bool>> predicate,
        NotificationIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(predicate)
            .IncludeWithState(includeState)
            .ToListAsync(cancellationToken);
    }

    public async Task<Notification?> GetByIdWithIncludeAsync(
        Guid id,
        NotificationIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(n => n.Id == id)
            .IncludeWithState(includeState)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IEnumerable<Notification>> GetUnreadNotificationsWithIncludeAsync(
        Guid userId,
        NotificationIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(n => n.UserId == userId && !n.IsRead)
            .IncludeWithState(includeState)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Notification>> GetByTypeWithIncludeAsync(
        string notificationType,
        NotificationIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(n => n.Type == notificationType)
            .IncludeWithState(includeState)
            .ToListAsync(cancellationToken);
    }
}