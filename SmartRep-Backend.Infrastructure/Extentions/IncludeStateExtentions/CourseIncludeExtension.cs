using Microsoft.EntityFrameworkCore;
using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;

namespace SmartRep_Backend.Infrastructure.Extentions.IncludeStateExtentions;
public static class CourseIncludeExtension
{
    public static IQueryable<Course> IncludeWithState(
        this IQueryable<Course> query,
        CourseIncludeState includeState)
    {
        if (includeState.IncludeTeacher)
            query = query.Include(c => c.Teacher);

        if (includeState.IncludeStudents)
            query = query.Include(c => c.Students);

        if (includeState.IncludeLessons)
            query = query.Include(c => c.Lessons);

        return query;
    }
}
