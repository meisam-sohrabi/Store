using Microsoft.AspNetCore.Identity;
using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Command.Permission
{
    public interface IPermissionCommandRepository
    {
        void Add(PermissionEntity permissionEntity);
        void Update(PermissionEntity permissionEntity);
        void Delete(PermissionEntity permissionEntity);

    }
}
