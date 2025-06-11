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
        if (includeState.IncludeTeacherProfile)
        {
            query = query.Include(c => c.TeacherProfile);

            if (includeState.IncludeTeacherUser)
            {
                query = query.Include(c => c.TeacherProfile.User);
            }
        }

        if (includeState.IncludeStudents)
        {
            query = query.Include(c => c.Students);

            if (includeState.IncludeStudentUsers)
            {
                query = query.Include(c => c.Students).ThenInclude(s => s.User);
            }
        }

        if (includeState.IncludeLessons)
            query = query.Include(c => c.Lessons);

        return query;
    }
}
