using Second.Domain.Entities;

namespace Second.InfrastructureContract.Interfaces.Query.Account
{
    public interface IAccountQueryRepository
    {
        Task<CustomUserEntity> GetUserById(string id);
        Task<CustomUserEntity> GetUserByUsername(string username);
        IQueryable<CustomUserEntity> GetQueryableUsers();
        Task<bool> RoleExist(string role);
        Task<IList<string>> Roles(CustomUserEntity user);
    }
}
