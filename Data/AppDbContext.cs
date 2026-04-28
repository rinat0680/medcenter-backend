using MedicalCenterApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalCenterApi;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}
