using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalCenterApi;

public class StaffMemberConfiguration : IEntityTypeConfiguration<StaffMember>
{
    public void Configure(EntityTypeBuilder<StaffMember> builder)
    {
        builder.ToTable("staff_members");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Firstname)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(s => s.Lastname)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(s => s.Specialization)
               .HasMaxLength(200);

        builder.Property(s => s.Position)
               .HasMaxLength(100);

        builder.Property(s => s.ContactNumber)
               .HasMaxLength(50);

        builder.HasIndex(s => s.UserId).IsUnique(); // связь один-к-одному с User
    }
}
