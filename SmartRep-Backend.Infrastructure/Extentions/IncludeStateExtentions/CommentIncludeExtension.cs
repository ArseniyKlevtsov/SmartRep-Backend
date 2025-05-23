using Microsoft.EntityFrameworkCore;
using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;

namespace SmartRep_Backend.Infrastructure.Extentions.IncludeStateExtentions;
public static class CommentIncludeExtension
{
    public static IQueryable<Comment> IncludeWithState(this IQueryable<Comment> query, CommentIncludeState includeState)
    {
        if (includeState.IncludeUser)
        {
            query = query.Include(comment => comment.User);
        }

        if (includeState.IncludeLesson)
        {
            query = query.Include(comment => comment.Lesson);
        }

        return query;
    }
}