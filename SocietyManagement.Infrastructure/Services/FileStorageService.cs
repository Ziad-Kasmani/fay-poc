using SocietyManagement.Application.Interfaces.Services;
using Microsoft.AspNetCore.Hosting;

namespace SocietyManagement.Infrastructure.Services;

public class FileStorageService : IFileStorageService
{
    private readonly IWebHostEnvironment _env;

    public FileStorageService(IWebHostEnvironment env)
    {
        _env = env;
    }

    public async Task<string> SaveFileAsync(Stream fileStream, string fileName)
    {
        var uploadDir = Path.Combine(_env.ContentRootPath, "wwwroot", "uploads");
        Directory.CreateDirectory(uploadDir);
        var filePath = Path.Combine(uploadDir, fileName);
        using var file = File.Create(filePath);
        await fileStream.CopyToAsync(file);
        return $"/uploads/{fileName}";
    }
}
