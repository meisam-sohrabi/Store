using Second.Domain.Entities;

namespace Second.InfrastructureContract.Interfaces.Command.Session
{
    public interface ISessionCommandRepository
    {
        Task Add(UserSessionEntity userSession);
        void Update(UserSessionEntity userSession);
    }
}
