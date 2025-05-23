using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;
using System.Linq.Expressions;

namespace SmartRep_Backend.Domain.interfaces.Repositories;
public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetWithIncludeAsync(CommentIncludeState includeState, CancellationToken cancellationToken);
    Task<IEnumerable<Comment>> GetWithIncludeByPredicateAsync(
        Expression<Func<Comment, bool>> predicate,
        CommentIncludeState includeState,
        CancellationToken cancellationToken);
}
