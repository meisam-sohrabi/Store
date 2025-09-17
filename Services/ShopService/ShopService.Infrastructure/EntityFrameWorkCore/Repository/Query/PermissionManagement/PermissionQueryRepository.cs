using Microsoft.EntityFrameworkCore;
using Second.InfrastructureContract.Interfaces.Query.Account;
using Second.InfrastructureContract.Interfaces.Query.PermisionManagement;

namespace Second.Infrastructure.EntityFrameWorkCore.Repository.Query.PermissionManagement
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
