using System;

namespace SocietyManagement.Domain.Entities;

public class OtpRecord
{
    public Guid Id { get; set; }
    public string Target { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public DateTime ExpiryTime { get; set; }
    public bool IsUsed { get; set; }
}
