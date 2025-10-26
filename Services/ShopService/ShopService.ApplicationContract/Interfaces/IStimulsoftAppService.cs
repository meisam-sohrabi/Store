namespace ShopService.ApplicationContract.Interfaces
{
    public interface IStimulsoftAppService<T>
    {
        Task<string> ReportToHtmlAsync(T data,string reportPath);
    }
}
