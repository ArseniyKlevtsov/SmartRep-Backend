namespace SmartRep_Backend.Application.Interfaces.Services;
public interface IPasswordService
{
    (string Hash, string Salt) CreatePasswordHash(string password);
    bool VerifyPassword(string password, string hash, string salt);
}
