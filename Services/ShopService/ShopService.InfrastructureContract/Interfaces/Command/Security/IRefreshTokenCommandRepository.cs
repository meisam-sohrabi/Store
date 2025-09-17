using Second.Domain.Entities;

namespace Second.InfrastructureContract.Interfaces.Command.Security
{
    public interface IRefreshTokenCommandRepository
    {
        Task Add(RefreshTokenEntity refreshToken);
        void Update(RefreshTokenEntity refreshToken);
        void Delete(RefreshTokenEntity refreshToken);
    }
}
