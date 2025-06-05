using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;
using System.Linq.Expressions;

namespace SmartRep_Backend.Domain.interfaces.Repositories;
public interface ILessonTaskRepository : IRepository<LessonTask>
{
    Task<IEnumerable<LessonTask>> GetWithIncludeAsync(
        LessonTaskIncludeState includeState,
        CancellationToken cancellationToken);

    Task<IEnumerable<LessonTask>> GetWithIncludeByPredicateAsync(
        Expression<Func<LessonTask, bool>> predicate,
        LessonTaskIncludeState includeState,
        CancellationToken cancellationToken);

    Task<LessonTask?> GetByIdWithIncludeAsync(
        Guid id,
        LessonTaskIncludeState includeState,
        CancellationToken cancellationToken);

    Task<IEnumerable<LessonTask>> GetBySolvedStatusWithIncludeAsync(
        bool isSolved,
        LessonTaskIncludeState includeState,
        CancellationToken cancellationToken);

    Task<List<LessonTask>?> GetByLessonIdAsync(
        Guid lessonId,
        CancellationToken cancellationToken);
}