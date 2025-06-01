using Microsoft.EntityFrameworkCore;
using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;

namespace SmartRep_Backend.Infrastructure.Extentions.IncludeStateExtentions;
public static class StudentProfileIncludeExtension
{
    public static IQueryable<StudentProfile> IncludeWithState(this IQueryable<StudentProfile> query, StudentProfileIncludeState includeState)
    {
        if (includeState.IncludeUser)
        {
            query = query.Include(comment => comment.User);
        }

        if (includeState.IncludeLessons)
        {
            query = query.Include(comment => comment.Lessons);
        }

        if (includeState.IncludeCourses)
        {
            query = query.Include(comment => comment.Courses);
        }

        return query;
    }
}
