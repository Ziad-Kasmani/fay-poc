using System;
using System.Collections.Generic;
using SocietyManagement.Domain.Enums;

namespace SocietyManagement.Domain.Entities;

public class Member
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string MobileNumber { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public bool IsEmailVerified { get; set; }
    public bool IsMobileVerified { get; set; }
    public MemberRole Role { get; set; }

    public Guid SocietyId { get; set; }
    public Society? Society { get; set; }

    public ICollection<Flat> Flats { get; set; } = new List<Flat>();
    public ICollection<Vote> Votes { get; set; } = new List<Vote>();
}
