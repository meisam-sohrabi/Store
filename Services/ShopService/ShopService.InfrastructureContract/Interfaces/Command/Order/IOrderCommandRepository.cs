using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Command.Order
{
    public interface IOrderCommandRepository
    {
        Task Add(OrderEntity order);
    }
}
