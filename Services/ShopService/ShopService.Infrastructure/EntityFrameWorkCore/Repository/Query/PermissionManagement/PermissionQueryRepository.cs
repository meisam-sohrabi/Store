using Microsoft.EntityFrameworkCore;
using ShopService.InfrastructureContract.Interfaces.Query.Account;
using ShopService.InfrastructureContract.Interfaces.Query.PermisionManagement;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.PermissionManagement
{
    public class PermissionQueryRepository : IPermissionQueryRepository
    {
        private readonly IAccountQueryRepository _accountQueryRepository;

        public PermissionQueryRepository(IAccountQueryRepository accountQueryRepository)
        {
            _accountQueryRepository = accountQueryRepository;
        }

        #region UserExist
        public async Task<bool> UserExist(string id)
        {
            return await _accountQueryRepository.GetQueryableUsers().AnyAsync(e => e.Id == id);
        }
        #endregion

    }
}
