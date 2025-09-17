using Second.Domain.Entities;

namespace Second.InfrastructureContract.Interfaces.Query.Session
{
    public interface ISessionQueryRepository
    {
         IQueryable<UserSessionEntity> GetSessionQueryable();
    }
}
