namespace SocietyManagement.Application.DTOs;

public class VerifyOtpDto
{
    public string Target { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
}
