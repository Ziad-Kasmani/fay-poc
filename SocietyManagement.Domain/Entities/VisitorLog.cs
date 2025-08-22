using System;

namespace SocietyManagement.Domain.Entities;

public class VisitorLog
{
    public Guid Id { get; set; }
    public string VisitorName { get; set; } = string.Empty;
    public string VisitorMobile { get; set; } = string.Empty;
    public string Purpose { get; set; } = string.Empty;
    public string PhotoUrl { get; set; } = string.Empty;
    public DateTime EntryTime { get; set; }
    public DateTime? ExitTime { get; set; }

    public Guid FlatId { get; set; }
    public Flat? Flat { get; set; }
}
