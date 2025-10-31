using ShopService.Domain.Entities;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Generic;
using ShopService.InfrastructureContract.Interfaces.Query.Category;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Category
{
    public class CategoryQueryRepository : GenericQueryRepository<CategoryEntity>,ICategoryQueryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryQueryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
