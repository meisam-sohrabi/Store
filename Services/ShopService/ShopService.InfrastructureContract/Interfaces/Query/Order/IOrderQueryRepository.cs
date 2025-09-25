using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Query.Order
{
    public interface IOrderQueryRepository
    {
        IQueryable<OrderEntity> GetQueryable();
    }
}
