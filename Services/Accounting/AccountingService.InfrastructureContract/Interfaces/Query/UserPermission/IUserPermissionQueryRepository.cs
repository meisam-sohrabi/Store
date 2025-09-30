using AccountingService.Domain.Entities;

namespace AccountingService.InfrastructureContract.Interfaces.Query.UserPermission
{
    public interface IUserPermissionQueryRepository
    {
        IQueryable<UserPermissoinEntity> GetQueryable();
    }
}
