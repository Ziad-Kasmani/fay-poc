using System;

namespace SocietyManagement.Domain.Entities;

public class Meeting
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Agenda { get; set; } = string.Empty;
    public DateTime ScheduledOn { get; set; }
    public string Location { get; set; } = string.Empty;
    public string? MinutesOfMeeting { get; set; }

    public Guid SocietyId { get; set; }
    public Society? Society { get; set; }
}
