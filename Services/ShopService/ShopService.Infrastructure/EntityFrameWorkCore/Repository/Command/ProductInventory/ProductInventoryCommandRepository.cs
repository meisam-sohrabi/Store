using ShopService.Domain.Entities;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using ShopService.InfrastructureContract.Interfaces.Command.ProductInventory;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.ProductInventory
{
    public class ProductInventoryCommandRepository : IProductInventoryCommandRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductInventoryCommandRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(ProductInventoryEntity productInventory)
        {
          await _context.productInventories.AddAsync(productInventory);
        }
       
    }
}
