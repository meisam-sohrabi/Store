using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopService.Domain.Entities;

namespace ShopService.Infrastructure.EntityFrameWorkCore.EntityConfigurations
{
    public class ProductBrandEntityConfiguration : IEntityTypeConfiguration<ProductBrandEntity>
    {
        public void Configure(EntityTypeBuilder<ProductBrandEntity> builder)
        {
            builder.ToTable("ProductBrands");
            builder.HasKey(e => e.Id);// ProductBrand can be unique 
            builder.Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Property(p => p.Description).HasMaxLength(350);
            builder.HasMany(e => e.Products)
                .WithOne(p => p.ProductBrand)
                .HasForeignKey(p => p.ProductBrandId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
