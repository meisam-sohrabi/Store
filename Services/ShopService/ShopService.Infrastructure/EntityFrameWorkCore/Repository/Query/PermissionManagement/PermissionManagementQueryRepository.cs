using Microsoft.EntityFrameworkCore;
using ShopService.InfrastructureContract.Interfaces.Query.Account;
using ShopService.InfrastructureContract.Interfaces.Query.PermisionManagement;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.PermissionManagement
{
    public class PermissionManagementQueryRepository : IPermissionManagementQueryRepository
    {
        private readonly IAccountQueryRepository _accountQueryRepository;

        public PermissionManagementQueryRepository(IAccountQueryRepository accountQueryRepository)
        {
            _accountQueryRepository = accountQueryRepository;
        }

        #region UserExist
        public async Task<bool> UserExist(string id)
        {
            return await _accountQueryRepository.GetQueryable().AnyAsync(e => e.Id == id);
        }
        #endregion

    }
}
