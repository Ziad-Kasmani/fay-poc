using SocietyManagement.Domain.Enums;

namespace SocietyManagement.Application.DTOs;

public class RegisterSocietyDto
{
    public string SocietyName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string RegistrationNumber { get; set; } = string.Empty;
    public string AdminFirstName { get; set; } = string.Empty;
    public string AdminLastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string MobileNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
