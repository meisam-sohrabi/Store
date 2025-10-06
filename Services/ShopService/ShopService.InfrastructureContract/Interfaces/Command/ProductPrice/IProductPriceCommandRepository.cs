using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Command.ProductPrice
{
    public interface IProductPriceCommandRepository
    {
        void Add(ProductPriceEntity productPrice);
        void Edit(ProductPriceEntity productPrice);
        void Delete(ProductPriceEntity productPrice);
    }
}
