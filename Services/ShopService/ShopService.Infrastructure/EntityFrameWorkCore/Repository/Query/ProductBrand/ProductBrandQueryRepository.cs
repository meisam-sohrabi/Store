using ShopService.Domain.Entities;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using ShopService.InfrastructureContract.Interfaces.Query.ProductBrand;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.ProductBrand
{
    public class ProductBrandQueryRepository : IProductBrandQueryRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductBrandQueryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<ProductBrandEntity> GetQueryable()
        {
            return _context.ProductBrands.AsQueryable();
        }
    }
}
