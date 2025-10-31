using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces.Query.Generic;

namespace ShopService.InfrastructureContract.Interfaces.Query.Category
{
    public interface ICategoryQueryRepository : IGenericQueryRepository<CategoryEntity>
    {
    }
}
