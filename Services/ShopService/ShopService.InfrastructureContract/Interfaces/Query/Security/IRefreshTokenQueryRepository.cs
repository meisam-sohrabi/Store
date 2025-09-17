using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Query.Security
{
    public interface IRefreshTokenQueryRepository
    {
        IQueryable<RefreshTokenEntity> GetRefreshTokenQueryable();
    }
}
