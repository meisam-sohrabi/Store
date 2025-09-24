using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Query.UserPermission
{
    public interface IUserPermissionQueryRepository
    {
        IQueryable<UserPermissoinEntity> GetQueryable();
    }
}
