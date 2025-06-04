using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;
using System.Linq.Expressions;

namespace SmartRep_Backend.Domain.interfaces.Repositories;
public interface ILessonRepository : IRepository<Lesson>
{
    Task<IEnumerable<Lesson>> GetWithIncludeAsync(
        LessonIncludeState includeState,
        CancellationToken cancellationToken);

    Task<IEnumerable<Lesson>> GetWithIncludeByPredicateAsync(
        Expression<Func<Lesson, bool>> predicate,
        LessonIncludeState includeState,
        CancellationToken cancellationToken);

    Task<Lesson?> GetByIdWithIncludeAsync(
        Guid id,
        LessonIncludeState includeState,
        CancellationToken cancellationToken);

    Task<IEnumerable<Lesson>> GetByTimeRangeWithIncludeAsync(
        DateTime startTime,
        DateTime endTime,
        LessonIncludeState includeState,
        CancellationToken cancellationToken);

    Task<IEnumerable<Lesson>> GetStudentLessonsByTimeAsync(
        Guid id,
        DateTime startTime,
        DateTime endTime,
        CancellationToken cancellationToken);

    Task<IEnumerable<Lesson>> GetTeacherLessonsByTimeAsync(
        Guid id,
        DateTime startTime,
        DateTime endTime,
        CancellationToken cancellationToken);
}
