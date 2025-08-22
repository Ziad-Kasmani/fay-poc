using System;
using System.Collections.Generic;

namespace SocietyManagement.Domain.Entities;

public class DomesticHelp
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PhotoUrl { get; set; } = string.Empty;
    public string MobileNumber { get; set; } = string.Empty;
    public string ServiceType { get; set; } = string.Empty;
    public Guid SocietyId { get; set; }
    public Society? Society { get; set; }

    public ICollection<Flat> ServicingFlats { get; set; } = new List<Flat>();
}
