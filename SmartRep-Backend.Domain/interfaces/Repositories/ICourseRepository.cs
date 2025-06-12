using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;
using System.Linq.Expressions;

namespace SmartRep_Backend.Domain.interfaces.Repositories;
public interface ICourseRepository: IRepository<Course>
{
    Task<IEnumerable<Course>> GetWithTeacherAndStudentsAsync(CancellationToken cancellationToken);

    Task<IEnumerable<Course>> GetWithIncludeAsync(
        CourseIncludeState includeState,
        CancellationToken cancellationToken);

    Task<IEnumerable<Course>> GetWithIncludeByPredicateAsync(
        Expression<Func<Course, bool>> predicate,
        CourseIncludeState includeState,
        CancellationToken cancellationToken);

    Task<Course?> GetByIdWithIncludeAsync(
        Guid id,
        CourseIncludeState includeState,
        CancellationToken cancellationToken);

    Task<Course?> GetWithStudentsAsync(Guid id, CancellationToken cancellationToken);
}