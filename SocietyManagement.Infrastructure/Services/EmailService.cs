using SocietyManagement.Application.Interfaces.Services;

namespace SocietyManagement.Infrastructure.Services;

public class EmailService : IEmailService
{
    public Task SendEmailAsync(string to, string subject, string body)
    {
        Console.WriteLine($"Email to {to} Subject:{subject} Body:{body}");
        return Task.CompletedTask;
    }
}
