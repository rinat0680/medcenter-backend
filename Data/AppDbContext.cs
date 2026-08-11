using MedicalCenterApi.Entities;
using Microsoft.EntityFrameworkCore;
using MedicalCenterApi.ServiceDomain;
namespace MedicalCenterApi;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<StaffMember> StaffMembers { get; set; }
    public DbSet<Service> Services { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
        modelBuilder.ApplyConfiguration<StaffMember>(new StaffMemberConfiguration());
        modelBuilder.ApplyConfiguration<Patient>(new PatientConfiguration());
        modelBuilder.ApplyConfiguration<RefreshToken>(new RefreshTokenConfiguration());
        modelBuilder.ApplyConfiguration<Service>(new ServiceConfiguration());
    }
}
