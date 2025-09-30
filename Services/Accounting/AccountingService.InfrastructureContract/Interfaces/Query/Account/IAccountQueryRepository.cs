using AccountingService.Domain.Entities;

namespace AccountingService.InfrastructureContract.Interfaces.Query.Account
{
    public interface IAccountQueryRepository
    {
        IQueryable<CustomUserEntity> GetQueryable();
    }
}
