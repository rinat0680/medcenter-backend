using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MedicalCenterApi.ServiceDomain;

namespace MedicalCenterApi;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable("services");

        builder.HasKey(s => s.Id);

        builder.Property(s => s.Name)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(s => s.Description)
               .HasMaxLength(1000);

        builder.Property(s => s.Price)
               .HasColumnType("decimal(18,2)");

        builder.Property(s => s.Duration)
               .IsRequired();

        // Seed data
        builder.HasData(
            new Service
            {
                Id = 1,
                Name = "Первичная консультация",
                Description = "Осмотр врача, сбор анамнеза, рекомендации",
                Price = 50.00m,
                Duration = TimeSpan.FromMinutes(30)
            },
            new Service
            {
                Id = 2,
                Name = "УЗИ органов брюшной полости",
                Description = "Ультразвуковое исследование органов брюшной полости",
                Price = 120.00m,
                Duration = TimeSpan.FromMinutes(45)
            },
            new Service
            {
                Id = 3,
                Name = "Анализ крови общий",
                Description = "Общий клинический анализ крови",
                Price = 20.00m,
                Duration = TimeSpan.FromMinutes(10)
            }
        );
    }
}
