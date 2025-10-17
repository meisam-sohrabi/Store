using ShopService.Domain.Entities;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using ShopService.InfrastructureContract.Interfaces.Query.Category;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Category
{
    public class CategoryQueryRepository : ICategoryQueryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryQueryRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        #region Get
        public IQueryable<CategoryEntity> GetQueryable()
        {
            return _context.Categories.AsQueryable();
        }
        #endregion

    }
}
