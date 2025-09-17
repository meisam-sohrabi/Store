using Second.Domain.Entities;

namespace Second.InfrastructureContract.Interfaces.Query.Auth
{
    public interface IAuthQueryRepository
    {
        Task<bool> CheckPassword(CustomUserEntity user, string password);

    }
}
