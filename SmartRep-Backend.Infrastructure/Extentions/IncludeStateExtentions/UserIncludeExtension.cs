using Microsoft.EntityFrameworkCore;
using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;

namespace SmartRep_Backend.Infrastructure.Extentions.IncludeStateExtentions;
public static class UserIncludeExtension
{
    public static IQueryable<User> IncludeWithState(
        this IQueryable<User> query,
        UserIncludeState includeState)
    {
        if (includeState.IncludeTeacherProfile)
            query = query.Include(u => u.TeacherProfile);

        if (includeState.IncludeStudentProfile)
            query = query.Include(u => u.StudentProfile);

        if (includeState.IncludeNotifications)
            query = query.Include(u => u.Notifications);

        if (includeState.IncludeComments)
            query = query.Include(u => u.Comments);

        return query;
    }
}