using Microsoft.AspNetCore.Identity;
using Second.Domain.Entities;
namespace Second.InfrastructureContract.Interfaces.Command.Account
{
    public interface IAccountCommandRepository
    {
        Task UpdateUser(CustomUserEntity user);
        Task DeleteUser(CustomUserEntity user);
        Task AddRole(IdentityRole role);
        Task AddRoleToUser(CustomUserEntity user, string role);
    }
}
