using System;

namespace SocietyManagement.Domain.Entities;

public class Expense
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime ExpenseDate { get; set; }
    public string Category { get; set; } = string.Empty;

    public Guid SocietyId { get; set; }
    public Society? Society { get; set; }
}
