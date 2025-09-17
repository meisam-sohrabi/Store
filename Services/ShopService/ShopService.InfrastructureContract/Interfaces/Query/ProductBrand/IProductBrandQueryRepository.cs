using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Query.ProductBrand
{
    public interface IProductBrandQueryRepository
    {
        IQueryable<ProductBrandEntity> GetQueryAble();
    }
}
