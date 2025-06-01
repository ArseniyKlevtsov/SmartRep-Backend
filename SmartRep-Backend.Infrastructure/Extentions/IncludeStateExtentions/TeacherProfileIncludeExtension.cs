using Microsoft.EntityFrameworkCore;
using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;

namespace SmartRep_Backend.Infrastructure.Extentions.IncludeStateExtentions;
public static class TeacherProfileIncludeExtension
{
    public static IQueryable<TeacherProfile> IncludeWithState(this IQueryable<TeacherProfile> query, TeacherProfileIncludeState includeState)
    {
        if (includeState.IncludeUser)
        {
            query = query.Include(comment => comment.User);
        }

        if (includeState.IncludeCourses)
        {
            query = query.Include(comment => comment.Courses);
        }

        return query;
    }
}
