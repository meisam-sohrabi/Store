namespace Second.InfrastructureContract.Interfaces.Query.PermisionManagement
{
    public interface IPermissionQueryRepository
    {
        Task<bool> UserExist(string id);
    }
}
