namespace ShopService.ApplicationContract.Interfaces
{
    public interface IStimulsoftAppService<T>
    {
        Task<string> ReportToJsonAsync(T data,string reportPath);
    }
}
