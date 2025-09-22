using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Query.Permission
{
    public interface IPermissionQueryRepository 
    {
        IQueryable<PermissionEntity> GetQueryable();
    }
}
