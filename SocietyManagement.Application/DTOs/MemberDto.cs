using SocietyManagement.Domain.Enums;

namespace SocietyManagement.Application.DTOs;

public class MemberDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string MobileNumber { get; set; } = string.Empty;
    public MemberRole Role { get; set; }
}
