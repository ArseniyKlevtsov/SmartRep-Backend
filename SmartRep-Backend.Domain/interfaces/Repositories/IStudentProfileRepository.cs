using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;
using System.Linq.Expressions;

namespace SmartRep_Backend.Domain.interfaces.Repositories;
public interface IStudentProfileRepository : IRepository<StudentProfile>
{
    Task<IEnumerable<StudentProfile>> GetWithIncludeAsync(StudentProfileIncludeState includeState, CancellationToken cancellationToken);
    Task<IEnumerable<StudentProfile>> GetWithIncludeByPredicateAsync(
        Expression<Func<StudentProfile, bool>> predicate,
        StudentProfileIncludeState includeState,
        CancellationToken cancellationToken);
}

