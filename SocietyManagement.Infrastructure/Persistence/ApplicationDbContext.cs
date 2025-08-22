using Microsoft.EntityFrameworkCore;
using SocietyManagement.Domain.Entities;

namespace SocietyManagement.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Society> Societies => Set<Society>();
    public DbSet<Member> Members => Set<Member>();
    public DbSet<Flat> Flats => Set<Flat>();
    public DbSet<OtpRecord> OtpRecords => Set<OtpRecord>();
    public DbSet<Vendor> Vendors => Set<Vendor>();
    public DbSet<DomesticHelp> DomesticHelps => Set<DomesticHelp>();
    public DbSet<VisitorLog> VisitorLogs => Set<VisitorLog>();
    public DbSet<Bill> Bills => Set<Bill>();
    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<Meeting> Meetings => Set<Meeting>();
    public DbSet<Poll> Polls => Set<Poll>();
    public DbSet<PollOption> PollOptions => Set<PollOption>();
    public DbSet<Vote> Votes => Set<Vote>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Member>()
            .HasIndex(m => m.Email).IsUnique();
        modelBuilder.Entity<Member>()
            .HasIndex(m => m.MobileNumber).IsUnique();

        modelBuilder.Entity<Member>()
            .HasMany(m => m.Flats)
            .WithMany(f => f.Members)
            .UsingEntity(j => j.ToTable("MemberFlats"));

        modelBuilder.Entity<DomesticHelp>()
            .HasMany(d => d.ServicingFlats)
            .WithMany(f => f.DomesticHelps)
            .UsingEntity(j => j.ToTable("DomesticHelpFlats"));

        modelBuilder.Entity<Vote>()
            .HasOne(v => v.Member)
            .WithMany(m => m.Votes)
            .HasForeignKey(v => v.MemberId);

        modelBuilder.Entity<Vote>()
            .HasOne(v => v.PollOption)
            .WithMany(o => o.Votes)
            .HasForeignKey(v => v.PollOptionId);

        base.OnModelCreating(modelBuilder);
    }
}
