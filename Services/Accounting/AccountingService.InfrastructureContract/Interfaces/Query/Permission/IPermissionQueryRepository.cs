using AccountingService.Domain.Entities;

namespace AccountingService.InfrastructureContract.Interfaces.Query.Permission
{
    public interface IPermissionQueryRepository 
    {
        IQueryable<PermissionEntity> GetQueryable();
    }
}
