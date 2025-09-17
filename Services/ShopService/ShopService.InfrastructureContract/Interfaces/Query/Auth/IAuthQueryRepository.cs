using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Query.Auth
{
    public interface IAuthQueryRepository
    {
        Task<bool> CheckPassword(CustomUserEntity user, string password);

    }
}
