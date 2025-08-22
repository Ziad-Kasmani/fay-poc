namespace SocietyManagement.Application.Interfaces.Services;

public interface IFileStorageService
{
    Task<string> SaveFileAsync(Stream fileStream, string fileName);
}
