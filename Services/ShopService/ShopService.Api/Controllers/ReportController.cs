using Microsoft.AspNetCore.Mvc;
using ShopService.ApplicationContract.DTO.Product;
using ShopService.ApplicationContract.Interfaces;
using ShopService.ApplicationContract.Interfaces.Product;

namespace ShopService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IProductAppService _productAppService;
        private readonly IStimulsoftAppService<List<ProductResponseDto>> _stimulsoftAppService;

        public ReportController(IProductAppService productAppService, IStimulsoftAppService<List<ProductResponseDto>> stimulsoftAppService)
        {
            _productAppService = productAppService;
            _stimulsoftAppService = stimulsoftAppService;
        }

        [HttpGet("ProductReport")]
        public async Task<IActionResult> ProductReport()
        {
            var products = await _productAppService.GetProductsReport();
            var reportPath = Path.Combine(Directory.GetCurrentDirectory(), "Reports", "Report.mrt");
            var report = await _stimulsoftAppService.ReportToJsonAsync(products, reportPath);
            return Ok(report);
        }
    }
}
