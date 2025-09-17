using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Command.Security
{
    public interface IRefreshTokenCommandRepository
    {
        Task Add(RefreshTokenEntity refreshToken);
        void Update(RefreshTokenEntity refreshToken);
        void Delete(RefreshTokenEntity refreshToken);
    }
}
