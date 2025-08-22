using System;
using System.Collections.Generic;

namespace SocietyManagement.Domain.Entities;

public class Poll
{
    public Guid Id { get; set; }
    public string Question { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsActive { get; set; }
    public Guid SocietyId { get; set; }
    public Society? Society { get; set; }

    public ICollection<PollOption> Options { get; set; } = new List<PollOption>();
}
