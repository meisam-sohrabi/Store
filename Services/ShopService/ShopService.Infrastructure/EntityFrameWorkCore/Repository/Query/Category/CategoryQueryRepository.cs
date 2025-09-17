using Microsoft.EntityFrameworkCore;
using Second.Domain.Entities;
using Second.Infrastructure.EntityFrameWorkCore.AppDbContext;
using Second.InfrastructureContract.Interfaces.Query.Category;

namespace Second.Infrastructure.EntityFrameWorkCore.Repository.Query.Category
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
