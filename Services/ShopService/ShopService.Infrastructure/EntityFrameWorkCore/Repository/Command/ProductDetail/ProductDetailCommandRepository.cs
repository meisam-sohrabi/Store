using ShopService.Domain.Entities;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using ShopService.InfrastructureContract.Interfaces.Command.ProductDetail;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.ProductDetail
{
    public class ProductDetailCommandRepository : IProductDetailCommandRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductDetailCommandRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(ProductDetailEntity productDetail)
        {
            _context.ProductDetails.Add(productDetail);
        }

        public void Delete(ProductDetailEntity productDetail)
        {
            _context.ProductDetails.Remove(productDetail);
        }

        public void Edit(ProductDetailEntity productDetail)
        {
            var entry = _context.Entry(productDetail);
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
