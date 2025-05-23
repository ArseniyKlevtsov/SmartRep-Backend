using Microsoft.EntityFrameworkCore;
using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;
using SmartRep_Backend.Domain.interfaces.Repositories;
using SmartRep_Backend.Infrastructure.Data;
using SmartRep_Backend.Infrastructure.Extentions.IncludeStateExtentions;
using System.Linq.Expressions;

namespace SmartRep_Backend.Infrastructure.Repositories;
public class LessonRepository : BaseRepository<Lesson>, ILessonRepository
{
    public LessonRepository(SmartRepDbContext context) : base(context) { }

    public async Task<IEnumerable<Lesson>> GetWithIncludeAsync(
        LessonIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .IncludeWithState(includeState)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Lesson>> GetWithIncludeByPredicateAsync(
        Expression<Func<Lesson, bool>> predicate,
        LessonIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(predicate)
            .IncludeWithState(includeState)
            .ToListAsync(cancellationToken);
    }

    public async Task<Lesson?> GetByIdWithIncludeAsync(
        Guid id,
        LessonIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(l => l.Id == id)
            .IncludeWithState(includeState)
            .FirstOrDefaultAsync(cancellationToken);
    }


    public async Task<IEnumerable<Lesson>> GetByTimeRangeWithIncludeAsync(
        DateTime startTime,
        DateTime endTime,
        LessonIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(l => l.StartTime >= startTime && l.EndTime <= endTime)
            .IncludeWithState(includeState)
            .ToListAsync(cancellationToken);
    }
}
