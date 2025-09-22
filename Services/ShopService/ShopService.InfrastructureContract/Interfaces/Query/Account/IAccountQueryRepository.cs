using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Query.Account
{
    public interface IAccountQueryRepository
    {
        //Task<CustomUserEntity> GetUserById(string id);
        //Task<CustomUserEntity> GetUserByUsername(string username);
        IQueryable<CustomUserEntity> GetQueryable();

    }
}
