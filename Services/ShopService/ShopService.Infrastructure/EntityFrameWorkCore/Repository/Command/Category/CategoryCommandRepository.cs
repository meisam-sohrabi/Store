using ShopService.Domain.Entities;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.Generic;
using ShopService.InfrastructureContract.Interfaces.Command.Category;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.Category
{
    public class CategoryCommandRepository : GenericCommandRepository<CategoryEntity>,ICategoryCommandRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryCommandRepository(ApplicationDbContext context) : base (context)
        {
            _context = context;
        }


    }
}
