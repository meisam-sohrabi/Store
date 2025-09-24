using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Command.UserPermission
{
    public interface IUserPermissionCommandRepository
    {
        Task AssignPermissionToUser(UserPermissoinEntity userPermissoinEntity);
        void RevokePermissionFromUser(UserPermissoinEntity userPermissoinEntity);
    }
}
