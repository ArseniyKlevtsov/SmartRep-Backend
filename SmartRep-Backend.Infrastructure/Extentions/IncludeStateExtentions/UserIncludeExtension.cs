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
        if (includeState.IncludeCoursesAsTeacher)
            query = query.Include(u => u.CoursesAsTeacher);

        if (includeState.IncludeCoursesAsStudent)
            query = query.Include(u => u.CoursesAsStudent);

        if (includeState.IncludeLessonsAsTeacher)
            query = query.Include(u => u.LessonsAsTeacher);

        if (includeState.IncludeLessonsAsStudent)
            query = query.Include(u => u.LessonsAsStudent);

        if (includeState.IncludeNotifications)
            query = query.Include(u => u.Notifications);

        if (includeState.IncludeComments)
            query = query.Include(u => u.Comments);

        return query;
    }
}