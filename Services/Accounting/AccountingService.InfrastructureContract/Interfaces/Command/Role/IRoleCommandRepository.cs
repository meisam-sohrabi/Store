using Microsoft.AspNetCore.Identity;
using AccountingService.Domain.Entities;

namespace AccountingService.InfrastructureContract.Interfaces.Command.Role
{
    public interface IRoleCommandRepository
    {
        Task<IdentityResult> Add(IdentityRole role);
        Task<IdentityResult> Update(IdentityRole role);
        Task<IdentityResult> Delete(IdentityRole role);
        Task<IdentityResult> AssignRoleToUser(CustomUserEntity user, string role);
        Task<IdentityResult> RevokeRoleFromUser(CustomUserEntity user, string role);

    }
}
