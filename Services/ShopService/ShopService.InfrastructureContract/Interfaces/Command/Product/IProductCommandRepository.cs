using Second.Domain.Entities;

namespace Second.InfrastructureContract.Interfaces.Command.Product
{
    public interface IProductCommandRepository
    {
        void Add(ProductEntity product);
        void Edit(ProductEntity product);
        void Delete(ProductEntity product);
    }
}
