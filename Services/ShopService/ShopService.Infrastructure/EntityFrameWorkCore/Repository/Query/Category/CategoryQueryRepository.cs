using Microsoft.EntityFrameworkCore;
using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces.Query.Category;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Category
{
    public class CategoryQueryRepository : ICategoryQueryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryQueryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region GetAll
        public IQueryable<CategoryEntity> GetAllQueryAble()
        {
            return _context.Categories.AsQueryable();
        }
        #endregion

        #region Get
        public IQueryable<CategoryEntity> GetQueryable()
        {
            return  _context.Categories.Include(c => c.Products).AsQueryable();
        }
        #endregion

    }
}
