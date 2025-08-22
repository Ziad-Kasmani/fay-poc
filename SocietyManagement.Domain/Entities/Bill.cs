using System;
using SocietyManagement.Domain.Enums;

namespace SocietyManagement.Domain.Entities;

public class Bill
{
    public Guid Id { get; set; }
    public string BillType { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime BillingPeriodStart { get; set; }
    public DateTime BillingPeriodEnd { get; set; }
    public DateTime DueDate { get; set; }
    public BillStatus Status { get; set; }

    public Guid FlatId { get; set; }
    public Flat? Flat { get; set; }
}
