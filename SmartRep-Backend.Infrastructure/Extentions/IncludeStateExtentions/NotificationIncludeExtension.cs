using Microsoft.EntityFrameworkCore;
using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;

namespace SmartRep_Backend.Infrastructure.Extentions.IncludeStateExtentions;
public static class NotificationIncludeExtension
{
    public static IQueryable<Notification> IncludeWithState(
        this IQueryable<Notification> query,
        NotificationIncludeState includeState)
    {
        if (includeState.IncludeUser)
            query = query.Include(n => n.User);

        if (includeState.IncludeLesson)
            query = query.Include(n => n.Lesson);

        return query;
    }
}
