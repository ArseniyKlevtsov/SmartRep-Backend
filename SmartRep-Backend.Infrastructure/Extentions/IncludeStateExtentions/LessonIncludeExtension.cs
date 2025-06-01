using Microsoft.EntityFrameworkCore;
using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;

namespace SmartRep_Backend.Infrastructure.Extentions.IncludeStateExtentions;
public static class LessonIncludeExtension
{
    public static IQueryable<Lesson> IncludeWithState(
        this IQueryable<Lesson> query,
        LessonIncludeState includeState)
    {
        if (includeState.IncludeCourse)
            query = query.Include(l => l.Course);

        if (includeState.IncludeStudentProfile)
            query = query.Include(l => l.StudentProfile);

        if (includeState.IncludeNotifications)
            query = query.Include(l => l.Notifications);

        if (includeState.IncludeLessonTasks)
            query = query.Include(l => l.LessonTasks);

        if (includeState.IncludeComments)
            query = query.Include(l => l.Comments);

        return query;
    }
}