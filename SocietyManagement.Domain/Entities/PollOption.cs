using System;
using System.Collections.Generic;

namespace SocietyManagement.Domain.Entities;

public class PollOption
{
    public Guid Id { get; set; }
    public string Text { get; set; } = string.Empty;
    public Guid PollId { get; set; }
    public Poll? Poll { get; set; }

    public ICollection<Vote> Votes { get; set; } = new List<Vote>();
}
