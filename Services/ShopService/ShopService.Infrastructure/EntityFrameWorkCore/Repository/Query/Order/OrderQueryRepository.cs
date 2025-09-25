using ShopService.Domain.Entities;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using ShopService.InfrastructureContract.Interfaces.Query.Order;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Order
{
    public class OrderQueryRepository : IOrderQueryRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderQueryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<OrderEntity> GetQueryable()
        {
           return _context.Orders.AsQueryable();
        }
    }
}
