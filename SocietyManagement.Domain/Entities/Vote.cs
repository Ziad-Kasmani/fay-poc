using System;

namespace SocietyManagement.Domain.Entities;

public class Vote
{
    public Guid Id { get; set; }
    public Guid MemberId { get; set; }
    public Member? Member { get; set; }

    public Guid PollOptionId { get; set; }
    public PollOption? PollOption { get; set; }
}
