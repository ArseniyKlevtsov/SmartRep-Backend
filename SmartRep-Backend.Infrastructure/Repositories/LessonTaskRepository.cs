using Microsoft.EntityFrameworkCore;
using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;
using SmartRep_Backend.Domain.interfaces.Repositories;
using SmartRep_Backend.Infrastructure.Data;
using SmartRep_Backend.Infrastructure.Extentions.IncludeStateExtentions;
using System.Linq.Expressions;

namespace SmartRep_Backend.Infrastructure.Repositories;
public class LessonTaskRepository : BaseRepository<LessonTask>, ILessonTaskRepository
{
    public LessonTaskRepository(SmartRepDbContext context) : base(context) { }

    public async Task<IEnumerable<LessonTask>> GetWithIncludeAsync(
        LessonTaskIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .IncludeWithState(includeState)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<LessonTask>> GetWithIncludeByPredicateAsync(
        Expression<Func<LessonTask, bool>> predicate,
        LessonTaskIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(predicate)
            .IncludeWithState(includeState)
            .ToListAsync(cancellationToken);
    }

    public async Task<LessonTask?> GetByIdWithIncludeAsync(
        Guid id,
        LessonTaskIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(lt => lt.Id == id)
            .IncludeWithState(includeState)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<List<LessonTask>?> GetByLessonIdAsync(
    Guid lessonId,
    CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(lt => lt.LessonId == lessonId)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<LessonTask>> GetBySolvedStatusWithIncludeAsync(
        bool isSolved,
        LessonTaskIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(lt => lt.IsSolved == isSolved)
            .IncludeWithState(includeState)
            .ToListAsync(cancellationToken);
    }
}
