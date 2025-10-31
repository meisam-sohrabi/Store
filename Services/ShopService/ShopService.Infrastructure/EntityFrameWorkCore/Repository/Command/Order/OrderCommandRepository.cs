using ShopService.Domain.Entities;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using ShopService.InfrastructureContract.Interfaces.Command.Order;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.Order
{
    public class OrderCommandRepository : IOrderCommandRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderCommandRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(OrderEntity order)
        {
            await _context.Orders.AddAsync(order);
        }

    }
}
