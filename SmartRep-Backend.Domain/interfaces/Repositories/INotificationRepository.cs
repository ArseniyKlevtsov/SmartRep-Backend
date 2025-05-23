using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;
using System.Linq.Expressions;

namespace SmartRep_Backend.Domain.interfaces.Repositories;
public interface INotificationRepository
{
    Task<IEnumerable<Notification>> GetWithIncludeAsync(
        NotificationIncludeState includeState,
        CancellationToken cancellationToken);

    Task<IEnumerable<Notification>> GetWithIncludeByPredicateAsync(
        Expression<Func<Notification, bool>> predicate,
        NotificationIncludeState includeState,
        CancellationToken cancellationToken);

    Task<Notification?> GetByIdWithIncludeAsync(
        Guid id,
        NotificationIncludeState includeState,
        CancellationToken cancellationToken);

    Task<IEnumerable<Notification>> GetUnreadNotificationsWithIncludeAsync(
        Guid userId,
        NotificationIncludeState includeState,
        CancellationToken cancellationToken);

    Task<IEnumerable<Notification>> GetByTypeWithIncludeAsync(
        string notificationType,
        NotificationIncludeState includeState,
        CancellationToken cancellationToken);
}