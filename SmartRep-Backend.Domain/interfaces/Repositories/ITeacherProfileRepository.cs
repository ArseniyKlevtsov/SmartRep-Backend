using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;
using System.Linq.Expressions;

namespace SmartRep_Backend.Domain.interfaces.Repositories;
public interface ITeacherProfileRepository: IRepository<TeacherProfile>
{
    Task<IEnumerable<TeacherProfile>> GetWithIncludeAsync(TeacherProfileIncludeState includeState, CancellationToken cancellationToken);
    Task<IEnumerable<TeacherProfile>> GetWithIncludeByPredicateAsync(
        Expression<Func<TeacherProfile, bool>> predicate,
        TeacherProfileIncludeState includeState,
        CancellationToken cancellationToken);
}
