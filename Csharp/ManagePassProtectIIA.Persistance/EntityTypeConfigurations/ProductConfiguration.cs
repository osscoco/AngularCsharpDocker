using ManagePassProtectIIA.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ManagePassProtectIIA.Persistance.EntityTypeConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Label).IsRequired().HasMaxLength(255);
            builder.HasOne(p => p.Type).WithMany(o => o.Products).HasForeignKey(c => c.TypeId).IsRequired();
            builder.Property(p => p.Created_at).HasColumnType("datetime").HasDefaultValue(DateTime.UtcNow);
            builder.Property(p => p.Updated_at).HasColumnType("datetime");
        }
    }
}
