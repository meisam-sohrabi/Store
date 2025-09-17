using Microsoft.AspNetCore.Identity;
using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Command.Auth
{
    public interface IAuthCommandRepository
    {
        Task<IdentityResult> Register(CustomUserEntity user, string password);

    }
}
