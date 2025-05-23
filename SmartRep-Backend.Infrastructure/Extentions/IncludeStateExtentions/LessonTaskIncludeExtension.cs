using Microsoft.EntityFrameworkCore;
using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;

namespace SmartRep_Backend.Infrastructure.Extentions.IncludeStateExtentions;
public static class LessonTaskIncludeExtension
{
    public static IQueryable<LessonTask> IncludeWithState(
        this IQueryable<LessonTask> query,
        LessonTaskIncludeState includeState)
    {
        if (includeState.IncludeLesson)
        {
            query = query.Include(lt => lt.Lesson);
        }

        return query;
    }
}