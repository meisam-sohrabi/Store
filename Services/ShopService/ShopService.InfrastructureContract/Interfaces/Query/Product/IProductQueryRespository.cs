using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Query.Product
{
    public interface IProductQueryRespository
    {
        IQueryable<ProductEntity> GetQueryable();
    }
}
