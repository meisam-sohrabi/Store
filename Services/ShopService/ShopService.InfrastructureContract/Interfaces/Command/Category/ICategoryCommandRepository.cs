using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Command.Category
{
    public interface ICategoryCommandRepository
    {
        void Add(CategoryEntity category);
        void Edit(CategoryEntity category);
        void Delete(CategoryEntity category);
    }
}
