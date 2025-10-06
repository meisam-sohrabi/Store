using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopService.Domain.Entities;

namespace ShopService.Infrastructure.EntityFrameWorkCore.EntityConfigurations
{
    public class ProductPriceEntityConfiguration : IEntityTypeConfiguration<ProductPriceEntity>
    {
        public void Configure(EntityTypeBuilder<ProductPriceEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p=> p.Price).HasPrecision(18,2).IsRequired();
            builder.HasOne(p=> p.Product)
                .WithMany(p=> p.ProductPrices)
                .HasForeignKey(p=> p.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
