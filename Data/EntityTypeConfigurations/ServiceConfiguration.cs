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
                Price = 50000.00m,
                Duration = TimeSpan.FromMinutes(30)
            },
            new Service
            {
                Id = 2,
                Name = "УЗИ органов брюшной полости",
                Description = "Ультразвуковое исследование органов брюшной полости",
                Price = 120000.00m,
                Duration = TimeSpan.FromMinutes(45)
            },
            new Service
            {
                Id = 3,
                Name = "Анализ крови общий",
                Description = "Общий клинический анализ крови",
                Price = 20000.00m,
                Duration = TimeSpan.FromMinutes(10)
            },
            new Service
            {
                Id = 4,
                Name = "Четвертая услуга",
                Description = "Услуга мед организации. Тут подробное описание услуги и дополнительная информация",
                Price = 920000.00m,
                Duration = TimeSpan.FromMinutes(210)
            },
            new Service
            {
                Id = 5,
                Name = "Удаление чего-то",
                Description = "Услуга мед организации. Тут подробное описание услуги и дополнительная информация",
                Price = 320000.00m,
                Duration = TimeSpan.FromMinutes(180)
            },
            new Service
            {
                Id = 6,
                Name = "Увеличение чего-то",
                Description = "Услуга мед организации. Тут подробное описание услуги и дополнительная информация",
                Price = 201000.00m,
                Duration = TimeSpan.FromMinutes(130)
            },
            new Service
            {
                Id = 7,
                Name = "Очистка и профилактика чего-то",
                Description = "Услуга мед организации. Тут подробное описание услуги и дополнительная информация",
                Price = 210000.00m,
                Duration = TimeSpan.FromMinutes(100)
            }
        );
    }
}
