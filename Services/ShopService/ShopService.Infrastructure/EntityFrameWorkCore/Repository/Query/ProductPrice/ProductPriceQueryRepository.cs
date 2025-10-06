using ShopService.Domain.Entities;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using ShopService.InfrastructureContract.Interfaces.Query.ProductPrice;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.ProductPrice
{
    public class ProductPriceQueryRepository : IProductPriceQueryRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductPriceQueryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<ProductPriceEntity> GetQueryable()
        {
            return _context.ProductPrices.AsQueryable();
        }
    }
}
