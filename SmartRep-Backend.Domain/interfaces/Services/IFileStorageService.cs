namespace SmartRep_Backend.Domain.interfaces.Services;
public interface IFileStorageService
{
    Task<string> SaveFileAsync(Stream fileStream, string fileName, string subFolder);
    Task DeleteFileAsync(string filePath);
    string GetFileUrl(string filePath);
}