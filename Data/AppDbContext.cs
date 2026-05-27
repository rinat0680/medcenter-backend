using MedicalCenterApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenterApi;

public class AppDbContext : DbContext
{
    public DbSet<User> users { get; set; }
    public DbSet<RefreshToken> refreshTokens { get; set; }

    public DbSet<Patient> patients { get; set; }
    public DbSet<StaffMember> staffMembers{ get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
