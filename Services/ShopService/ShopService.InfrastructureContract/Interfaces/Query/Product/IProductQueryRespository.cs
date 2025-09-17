using Second.Domain.Entities;

namespace Second.InfrastructureContract.Interfaces.Query.Product
{
    public interface IProductQueryRespository
    {
        IQueryable<ProductEntity> GetQueryAble();
        IQueryable<ProductEntity> GetAllQueryAble();
    }
}
