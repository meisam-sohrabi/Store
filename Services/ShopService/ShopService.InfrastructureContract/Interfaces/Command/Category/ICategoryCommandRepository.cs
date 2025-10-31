using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces.Command.Generic;

namespace ShopService.InfrastructureContract.Interfaces.Command.Category
{
    public interface ICategoryCommandRepository : IGenericCommandRepository<CategoryEntity>
    {

        // later implementation here but generic is enough for now.
    }
}
