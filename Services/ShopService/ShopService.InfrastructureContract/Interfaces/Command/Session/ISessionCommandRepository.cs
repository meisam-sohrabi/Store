using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Command.Session
{
    public interface ISessionCommandRepository
    {
        Task Add(UserSessionEntity userSession);
        void Update(UserSessionEntity userSession);
    }
}
