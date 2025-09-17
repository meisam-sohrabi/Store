using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Query.Session
{
    public interface ISessionQueryRepository
    {
         IQueryable<UserSessionEntity> GetSessionQueryable();
    }
}
