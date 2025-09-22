namespace ShopService.InfrastructureContract.Interfaces.Query.PermisionManagement
{
    public interface IPermissionManagementQueryRepository
    {
        Task<bool> UserExist(string id);
    }
}
