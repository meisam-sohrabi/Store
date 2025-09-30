using AccountingService.Domain.Entities;

namespace AccountingService.InfrastructureContract.Interfaces.Command.UserPermission
{
    public interface IUserPermissionCommandRepository
    {
        Task AssignPermissionToUser(UserPermissoinEntity userPermissoinEntity);
        void RevokePermissionFromUser(UserPermissoinEntity userPermissoinEntity);
    }
}
