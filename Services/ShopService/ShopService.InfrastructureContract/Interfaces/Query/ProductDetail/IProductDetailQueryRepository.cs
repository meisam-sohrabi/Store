using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Query.ProductDetail
{
    public interface IProductDetailQueryRepository
    {
        IQueryable<ProductDetailEntity> GetQueryable();
    }
}
