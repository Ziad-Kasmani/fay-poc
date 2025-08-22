using System;
using System.Collections.Generic;

namespace SocietyManagement.Domain.Entities;

public class Society
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string RegistrationNumber { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }

    public ICollection<Member> Members { get; set; } = new List<Member>();
    public ICollection<Flat> Flats { get; set; } = new List<Flat>();
    public ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();
    public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    public ICollection<Meeting> Meetings { get; set; } = new List<Meeting>();
    public ICollection<Poll> Polls { get; set; } = new List<Poll>();
}
