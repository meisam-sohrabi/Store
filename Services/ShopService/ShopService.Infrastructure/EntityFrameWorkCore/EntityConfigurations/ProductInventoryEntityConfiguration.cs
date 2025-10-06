using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopService.Domain.Entities;

namespace ShopService.Infrastructure.EntityFrameWorkCore.EntityConfigurations
{
    public class ProductInventoryEntityConfiguration : IEntityTypeConfiguration<ProductInventoryEntity>
    {
        public void Configure(EntityTypeBuilder<ProductInventoryEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.QuantityChange).IsRequired();
            builder.HasOne(p=> p.Product)
                .WithMany(p=> p.ProductInventories)
                .HasForeignKey(p=>p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
