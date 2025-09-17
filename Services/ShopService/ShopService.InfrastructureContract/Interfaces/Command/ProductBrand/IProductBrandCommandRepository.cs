using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Command.ProductBrand
{
    public interface IProductBrandCommandRepository
    {
        void Add(ProductBrandEntity productBrand);
        void Edit(ProductBrandEntity productBrand);
        void Delete(ProductBrandEntity productBrand);
    }
}
