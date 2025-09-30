using Microsoft.AspNetCore.Identity;
using AccountingService.Domain.Entities;

namespace AccountingService.InfrastructureContract.Interfaces.Command.Permission
{
    public interface IPermissionCommandRepository
    {
        void Add(PermissionEntity permissionEntity);
        void Update(PermissionEntity permissionEntity);
        void Delete(PermissionEntity permissionEntity);

    }
}
