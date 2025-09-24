using ShopService.Domain.Entities;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using ShopService.InfrastructureContract.Interfaces.Command.ProductBrand;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.ProductBrand
{
    public class ProductBrandCommandRepository : IProductBrandCommandRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductBrandCommandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(ProductBrandEntity productBrand)
        {
            _context.ProductBrands.Add(productBrand);
        }

        public void Delete(ProductBrandEntity productBrand)
        {
            _context.ProductBrands.Remove(productBrand);
        }

        public void Edit(ProductBrandEntity productBrand)
        {
            var entry = _context.Entry(productBrand);
            var key = _context.Model.FindEntityType(typeof(ProductEntity))?.FindPrimaryKey();
            if (key != null)
            {
                foreach (var property in key.Properties)
                {
                    entry.Property(property.Name).IsModified = false;
                }
            }
        }
    }
}
