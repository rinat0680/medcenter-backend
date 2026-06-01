using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalCenterApi;

public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("refresh_tokens");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Token)
               .IsRequired()
               .HasMaxLength(512);

        builder.HasIndex(r => r.UserId); // связь многие-к-одному с User
    }
}
