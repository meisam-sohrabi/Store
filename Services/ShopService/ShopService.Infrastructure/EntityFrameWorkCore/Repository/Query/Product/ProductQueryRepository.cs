using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces.Query.Product;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Product
{
    public class ProductQueryRepository : IProductQueryRespository
    {
        private readonly ApplicationDbContext _context;

        public ProductQueryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region GetAll
        public IQueryable<ProductEntity> GetAllQueryAble()
        {
            return _context.Products.AsQueryable();
        }
        #endregion

        #region Get
        public IQueryable<ProductEntity> GetQueryAble()
        {
            return _context.Products.AsQueryable();
        }
        #endregion

    }
}
