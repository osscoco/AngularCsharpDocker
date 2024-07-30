using ManagePassProtectIIA.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ManagePassProtectIIA.Persistance.EntityTypeConfigurations
{
    public class TypeConfiguration : IEntityTypeConfiguration<Models.Type>
    {
        public void Configure(EntityTypeBuilder<Models.Type> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Label).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Created_at).HasColumnType("datetime").HasDefaultValue(DateTime.UtcNow);
            builder.Property(p => p.Updated_at).HasColumnType("datetime");
        }
    }
}
