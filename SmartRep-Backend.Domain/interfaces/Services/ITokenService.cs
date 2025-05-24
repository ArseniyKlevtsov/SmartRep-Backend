
using System.Security.Claims;

namespace SmartRep_Backend.Domain.interfaces.Services;
public interface ITokenService
{
    string GenerateJwtToken(IEnumerable<Claim> claims);

    ClaimsPrincipal? ValidateToken(string token);
}
