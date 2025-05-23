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

        if (includeState.IncludeTeacher)
            query = query.Include(l => l.Teacher);

        if (includeState.IncludeStudent)
            query = query.Include(l => l.Student);

        if (includeState.IncludeNotifications)
            query = query.Include(l => l.Notifications);

        if (includeState.IncludeLessonTasks)
            query = query.Include(l => l.LessonTasks);

        if (includeState.IncludeComments)
            query = query.Include(l => l.Comments);

        return query;
    }
}