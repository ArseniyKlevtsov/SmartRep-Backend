using Microsoft.EntityFrameworkCore;
using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;
using SmartRep_Backend.Domain.interfaces.Repositories;
using SmartRep_Backend.Infrastructure.Data;
using SmartRep_Backend.Infrastructure.Extentions.IncludeStateExtentions;
using System.Linq.Expressions;

namespace SmartRep_Backend.Infrastructure.Repositories;
public class TeacherProfileRepository : BaseRepository<TeacherProfile>, ITeacherProfileRepository
{
    public TeacherProfileRepository(SmartRepDbContext context) : base(context) { }

    public async Task<IEnumerable<TeacherProfile>> GetWithIncludeAsync(TeacherProfileIncludeState includeState, CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .IncludeWithState(includeState)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<TeacherProfile>> GetWithIncludeByPredicateAsync(Expression<Func<TeacherProfile, bool>> predicate, TeacherProfileIncludeState includeState, CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(predicate)
            .IncludeWithState(includeState)
            .ToListAsync(cancellationToken);
    }
}
