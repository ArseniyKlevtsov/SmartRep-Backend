using SmartRep_Backend.Domain.Entities;
using SmartRep_Backend.Domain.IncludeStates;
using System.Linq.Expressions;

namespace SmartRep_Backend.Domain.interfaces.Repositories;
public interface IUserRepository : IRepository<User>
{
    Task<IEnumerable<User>> GetWithIncludeAsync(
        UserIncludeState includeState,
        CancellationToken cancellationToken);

    Task<IEnumerable<User>> GetWithIncludeByPredicateAsync(
        Expression<Func<User, bool>> predicate,
        UserIncludeState includeState,
        CancellationToken cancellationToken);

    Task<User?> GetByIdWithIncludeAsync(
        Guid id,
        UserIncludeState includeState,
        CancellationToken cancellationToken);

    Task<User?> GetByEmailWithIncludeAsync(
        string email,
        UserIncludeState includeState,
        CancellationToken cancellationToken);

    Task<IEnumerable<User>> GetUsersByNamesAsync(IEnumerable<string> usernames, CancellationToken cancellationToken);
}
