using ShopService.Domain.Entities;
namespace ShopService.InfrastructureContract.Interfaces.Command.Account
{
    public interface IAccountCommandRepository
    {
        Task UpdateUser(CustomUserEntity user);
        Task DeleteUser(CustomUserEntity user);
    }
}
