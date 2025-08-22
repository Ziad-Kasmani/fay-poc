using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using SocietyManagement.Application.Interfaces.Services;
using SocietyManagement.Domain.Entities;
using SocietyManagement.Infrastructure.Persistence;

namespace SocietyManagement.Infrastructure.Services;

public class OtpService : IOtpService
{
    private readonly ApplicationDbContext _context;

    public OtpService(ApplicationDbContext context) => _context = context;

    public async Task<string> GenerateOtpAsync(string target)
    {
        var code = RandomNumberGenerator.GetInt32(100000, 999999).ToString();
        var record = new OtpRecord
        {
            Id = Guid.NewGuid(),
            Target = target,
            Code = code,
            ExpiryTime = DateTime.UtcNow.AddMinutes(5),
            IsUsed = false
        };
        await _context.OtpRecords.AddAsync(record);
        await _context.SaveChangesAsync();
        Console.WriteLine($"OTP for {target}: {code}");
        return code;
    }

    public async Task<bool> VerifyOtpAsync(string target, string code)
    {
        var record = await _context.OtpRecords.FirstOrDefaultAsync(o => o.Target == target && o.Code == code && !o.IsUsed && o.ExpiryTime > DateTime.UtcNow);
        if (record == null) return false;
        record.IsUsed = true;
        await _context.SaveChangesAsync();
        return true;
    }
}
