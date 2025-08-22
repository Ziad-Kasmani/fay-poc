using System;
using System.Collections.Generic;

namespace SocietyManagement.Domain.Entities;

public class Flat
{
    public Guid Id { get; set; }
    public string UnitNumber { get; set; } = string.Empty;

    public Guid SocietyId { get; set; }
    public Society? Society { get; set; }

    public ICollection<Member> Members { get; set; } = new List<Member>();
    public ICollection<VisitorLog> VisitorLogs { get; set; } = new List<VisitorLog>();
    public ICollection<Bill> Bills { get; set; } = new List<Bill>();
    public ICollection<DomesticHelp> DomesticHelps { get; set; } = new List<DomesticHelp>();
}
