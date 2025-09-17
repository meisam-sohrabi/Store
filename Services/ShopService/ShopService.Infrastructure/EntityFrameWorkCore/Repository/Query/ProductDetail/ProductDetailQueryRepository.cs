using ShopService.Domain.Entities;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using ShopService.InfrastructureContract.Interfaces.Query.ProductDetail;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.ProductDetail
{
    public class ProductDetailQueryRepository : IProductDetailQueryRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductDetailQueryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<ProductDetailEntity> GetQueryAble()
        {
            return _context.ProductDetails.AsQueryable();
        }
    }
}
