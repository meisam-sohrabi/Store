using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Query.Account
{
    public interface IAccountQueryRepository
    {
        IQueryable<CustomUserEntity> GetQueryable();
    }
}

