using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Query.Category
{
    public interface ICategoryQueryRepository
    {
        IQueryable<CategoryEntity> GetQueryable();
        IQueryable<CategoryEntity> GetAllQueryAble();
    }
}
