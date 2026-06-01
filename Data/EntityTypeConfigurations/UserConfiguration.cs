using MedicalCenterApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalCenterApi;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Имя таблицы
        builder.ToTable("users");

        // Первичный ключ
        builder.HasKey(u => u.Id);

        // Поля
        builder.Property(u => u.Username).IsRequired().HasMaxLength(100);

        builder.Property(u => u.Password).IsRequired().HasMaxLength(256);

        builder.Property(u => u.Email).IsRequired().HasMaxLength(256);

        // Уникальные индексы
        builder.HasIndex(u => u.Email).IsUnique();
        builder.HasIndex(u => u.Username).IsUnique();

        // Флаг IsAdmin
        builder.Property(u => u.IsAdmin).HasDefaultValue(false);

        // Связи
        builder.HasOne<Patient>()
               .WithOne()
               .HasForeignKey<Patient>(p => p.UserId);

        builder.HasOne<StaffMember>()
               .WithOne()
               .HasForeignKey<StaffMember>(s => s.UserId);

        builder.HasOne<RefreshToken>()
               .WithOne()
               .HasForeignKey<RefreshToken>(r => r.UserId);
    }
}
