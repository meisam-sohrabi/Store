using Second.ApplicationContract.DTO.Security;
using Second.Domain.Entities;

namespace Second.InfrastructureContract.Interfaces.Query.Security
{
    public interface IRefreshTokenQueryRepository
    {
        Task<RefreshTokenEntity> GetRefreshToken(RefreshTokenRequestDto tokenRequestDto);
        Task<RefreshTokenEntity> GetRefreshTokenByUserId(string userId);

    }
}
