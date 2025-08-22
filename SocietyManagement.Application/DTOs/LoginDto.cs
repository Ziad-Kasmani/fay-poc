namespace SocietyManagement.Application.DTOs;

public class LoginDto
{
    public string EmailOrMobile { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
