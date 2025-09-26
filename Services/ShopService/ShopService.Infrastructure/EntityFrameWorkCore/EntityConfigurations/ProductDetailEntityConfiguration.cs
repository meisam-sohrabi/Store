using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopService.Domain.Entities;

namespace ShopService.Infrastructure.EntityFrameWorkCore.EntityConfigurations
{
    public class ProductDetailEntityConfiguration : IEntityTypeConfiguration<ProductDetailEntity>
    {
        public void Configure(EntityTypeBuilder<ProductDetailEntity> builder)
        {
            builder.ToTable("ProductDetails");
            builder.HasKey(e => e.Id);
            builder.Property(p => p.Size).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Description).HasMaxLength(350);
            builder.Property(p => p.Price).HasPrecision(18, 2);
            builder.HasOne(p => p.Product)
                .WithMany(p => p.ProductDetails)
                .HasForeignKey(e => e.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
