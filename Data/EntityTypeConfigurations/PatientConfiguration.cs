using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalCenterApi;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        // Имя таблицы
        builder.ToTable("patients");
        // Первичный ключ
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Firstname)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(p => p.Lastname)
               .IsRequired()
               .HasMaxLength(100);

        // Уникальный индекс
        builder.HasIndex(p => p.UserId).IsUnique();
    }
}
