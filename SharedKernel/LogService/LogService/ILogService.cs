namespace LogService
{
    public interface ILogService
    {
        Task LogAsync(string message, string appServiceName, string currentuser);
    }
}
