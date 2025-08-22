using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using SocietyManagement.Domain.Enums;

namespace SocietyManagement.Domain.Entities;

public class Member : IdentityUser<Guid>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public MemberRole Role { get; set; }

    public Guid SocietyId { get; set; }
    public Society? Society { get; set; }

    public ICollection<Flat> Flats { get; set; } = new List<Flat>();
    public ICollection<Vote> Votes { get; set; } = new List<Vote>();
}
