using SocietyManagement.Domain.Enums;

namespace SocietyManagement.Application.DTOs;

public class RegisterMemberDto
{
    public Guid SocietyId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string MobileNumber { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public MemberRole Role { get; set; }
}
