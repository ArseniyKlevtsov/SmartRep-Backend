using Microsoft.EntityFrameworkCore;
using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;
using SmartRep_Backend.Domain.interfaces.Repositories;
using SmartRep_Backend.Infrastructure.Data;
using SmartRep_Backend.Infrastructure.Extentions.IncludeStateExtentions;
using System.Linq.Expressions;

namespace SmartRep_Backend.Infrastructure.Repositories;
public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(SmartRepDbContext context) : base(context) { }

    public async Task<IEnumerable<User>> GetWithIncludeAsync(
        UserIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .IncludeWithState(includeState)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<User>> GetWithIncludeByPredicateAsync(
        Expression<Func<User, bool>> predicate,
        UserIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(predicate)
            .IncludeWithState(includeState)
            .ToListAsync(cancellationToken);
    }

    public async Task<User?> GetByIdWithIncludeAsync(
        Guid id,
        UserIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(u => u.Id == id)
            .IncludeWithState(includeState)
            .FirstOrDefaultAsync(cancellationToken);
    }
    public async Task<User?> GetByEmailWithIncludeAsync(
        string email,
        UserIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(u => u.Email == email)
            .IncludeWithState(includeState)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IEnumerable<User>> GetTeachersWithIncludeAsync(
        UserIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(u => u.CoursesAsTeacher.Any())
            .IncludeWithState(includeState)
            .ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<User>> GetStudentsWithIncludeAsync(
        UserIncludeState includeState,
        CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .Where(u => u.CoursesAsStudent.Any())
            .IncludeWithState(includeState)
            .ToListAsync(cancellationToken);
    }
}
