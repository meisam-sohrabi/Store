using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Query.ProductPrice
{
    public interface IProductPriceQueryRepository
    {
        IQueryable<ProductPriceEntity> GetQueryable();
    }
}
