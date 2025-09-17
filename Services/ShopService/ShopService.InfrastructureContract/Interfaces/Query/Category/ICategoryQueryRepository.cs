using Second.Domain.Entities;

namespace Second.InfrastructureContract.Interfaces.Query.Category
{
    public interface ICategoryQueryRepository
    {
        IQueryable<CategoryEntity> GetQueryable();
        IQueryable<CategoryEntity> GetAllQueryAble();
    }
}
