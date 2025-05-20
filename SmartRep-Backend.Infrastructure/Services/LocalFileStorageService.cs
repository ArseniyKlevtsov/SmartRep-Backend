using Microsoft.Extensions.Configuration;
using SmartRep_Backend.Domain.interfaces.Services;

namespace SmartRep_Backend.Infrastructure.Services;
public class LocalFileStorageService : IFileStorageService
{
    private readonly string _basePath;
    private readonly string _baseUrl;

    public LocalFileStorageService(IConfiguration config)
    {
        _basePath = Path.Combine(Directory.GetCurrentDirectory(), "data/files");
        _baseUrl = config["FileStorage:BaseUrl"] ?? "https://localhost:5001/static-files";

        Directory.CreateDirectory(_basePath); // Создаем папку если нет
    }

    public async Task<string> SaveFileAsync(Stream fileStream, string fileName, string subFolder)
    {
        var folderPath = Path.Combine(_basePath, subFolder);
        Directory.CreateDirectory(folderPath);

        var filePath = Path.Combine(folderPath, fileName);
        await using var fs = new FileStream(filePath, FileMode.Create);
        await fileStream.CopyToAsync(fs);

        return Path.Combine(subFolder, fileName);
    }

    public Task DeleteFileAsync(string filePath)
    {
        var fullPath = Path.Combine(_basePath, filePath);
        if (File.Exists(fullPath))
            File.Delete(fullPath);

        return Task.CompletedTask;
    }

    public string GetFileUrl(string filePath)
    {
        return $"{_baseUrl}/{filePath.Replace('\\', '/')}";
    }
}