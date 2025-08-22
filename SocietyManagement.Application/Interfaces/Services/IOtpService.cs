namespace SocietyManagement.Application.Interfaces.Services;

public interface IOtpService
{
    Task<string> GenerateOtpAsync(string target);
    Task<bool> VerifyOtpAsync(string target, string code);
}
