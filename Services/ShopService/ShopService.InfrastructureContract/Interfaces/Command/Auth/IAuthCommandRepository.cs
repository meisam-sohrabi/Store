using Microsoft.AspNetCore.Identity;
using Second.Domain.Entities;

namespace Second.InfrastructureContract.Interfaces.Command.Auth
{
    public interface IAuthCommandRepository
    {
        Task<IdentityResult> Register(CustomUserEntity user, string password);

    }
}
