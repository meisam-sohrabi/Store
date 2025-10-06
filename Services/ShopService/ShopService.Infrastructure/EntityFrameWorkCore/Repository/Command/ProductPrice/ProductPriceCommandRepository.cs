using ShopService.Domain.Entities;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using ShopService.InfrastructureContract.Interfaces.Command.ProductPrice;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.ProductPrice
{
    public class ProductPriceCommandRepository : IProductPriceCommandRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductPriceCommandRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(ProductPriceEntity productPrice)
        {
            _context.ProductPrices.Add(productPrice);
        }

        public void Delete(ProductPriceEntity productPrice)
        {
            _context.ProductPrices.Remove(productPrice);
        }

        public void Edit(ProductPriceEntity productPrice)
        {
            var entry = _context.Entry(productPrice);
            var key = _context.Model.FindEntityType(typeof(ProductPriceEntity))?.FindPrimaryKey();
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
