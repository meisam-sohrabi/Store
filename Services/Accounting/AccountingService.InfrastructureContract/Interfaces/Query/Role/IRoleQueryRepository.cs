using Microsoft.AspNetCore.Identity;
using AccountingService.Domain.Entities;

namespace AccountingService.InfrastructureContract.Interfaces.Query.Role
{
    public interface IRoleQueryRepository
    {
        Task<bool> RoleExist(string role);
        Task<IdentityRole> GetRoleByName(string role);
        Task<IList<CustomUserEntity>> GetUsersInRole(string role);
        IQueryable<IdentityRole> GetAllRoles();
        Task<IList<string>> Roles(CustomUserEntity user);
    }
}
