using Microsoft.EntityFrameworkCore;
using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;
using SmartRep_Backend.Domain.interfaces.Repositories;
using SmartRep_Backend.Infrastructure.Data;
using SmartRep_Backend.Infrastructure.Extentions.IncludeStateExtentions;
using System.Linq.Expressions;

namespace SmartRep_Backend.Infrastructure.Repositories;
public class CourseRepository : BaseRepository<Course>, ICourseRepository
{
    public CourseRepository(SmartRepDbContext context) : base(context) { }

    public async Task<IEnumerable<Course>> GetWithTeacherAndStudentsAsync(CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(c => c.TeacherProfile)
            .ThenInclude(tp => tp.User)
            .Include(c => c.Students)
            .ThenInclude(s => s.User)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Course>> GetWithIncludeAsync(
        CourseIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .IncludeWithState(includeState)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Course>> GetWithIncludeByPredicateAsync(
        Expression<Func<Course, bool>> predicate,
        CourseIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(predicate)
            .IncludeWithState(includeState)
            .ToListAsync(cancellationToken);
    }

    public async Task<Course?> GetByIdWithIncludeAsync(
        Guid id,
        CourseIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(c => c.Id == id)
            .IncludeWithState(includeState)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<Course?> GetWithStudentsAsync(Guid id,CancellationToken cancellationToken)
    {
        return await _dbSet
            .Include(c => c.Students)
            .ThenInclude(tp => tp.User)
            .FirstOrDefaultAsync( c => c.Id == id,cancellationToken);
    }
}
