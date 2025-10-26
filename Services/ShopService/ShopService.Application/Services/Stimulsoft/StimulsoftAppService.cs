using ShopService.ApplicationContract.Interfaces;
using Stimulsoft.Report;

namespace ShopService.Application.Services.Stimulsoft
{
    public class StimulsoftAppService<T> : IStimulsoftAppService<T>
    {

        public async Task<string> ReportToJsonAsync(T data, string reportPath)
        {

            using (var report = StiReport.CreateNewReport())
            {
                report.Load(reportPath);
                report.RegData("productdt", data);
                await report.RenderAsync();
                return report.SaveDocumentJsonToString();
            }
        }
    }
}
