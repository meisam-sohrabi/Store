using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces.Command.Category;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.Category
{
    public class CategoryCommandRepository : ICategoryCommandRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryCommandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Add
        public void Add(CategoryEntity category)
        {
            _context.Categories.Add(category);
        }
        #endregion

        #region Delete
        public void Delete(CategoryEntity category)
        {
            _context.Remove(category);
        }
        #endregion

        #region Edit
        public void Edit(CategoryEntity category)
        {
            _context.Update(category);
        }
        #endregion
    }
}
