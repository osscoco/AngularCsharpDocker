using ManagePassProtectIIA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagePassProtectIIA.Persistance.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Username).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Password).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Firstname).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Lastname).IsRequired().HasMaxLength(255);
            builder.Property(p => p.IsAdmin).HasColumnType("bit").HasDefaultValue(false);
            builder.Property(p => p.Created_at).HasColumnType("datetime").HasDefaultValue(DateTime.UtcNow);
            builder.Property(p => p.Updated_at).HasColumnType("datetime");
        }
    }
}
