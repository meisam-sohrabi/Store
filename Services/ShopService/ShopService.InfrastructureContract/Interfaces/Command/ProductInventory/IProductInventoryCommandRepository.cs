using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Command.ProductInventory
{
    public interface IProductInventoryCommandRepository
    {
        Task Add(ProductInventoryEntity productInventory);
    }
}
