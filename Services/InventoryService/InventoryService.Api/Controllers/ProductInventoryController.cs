using InventoryService.ApplicationContract.DTO.Base;
using InventoryService.ApplicationContract.DTO.ProductInventory;
using InventoryService.ApplicationContract.Interfaces.ProductInventory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductInventoryController : ControllerBase
    {
        private readonly IProductInventoryAppService _productInventoryAppService;

        public ProductInventoryController(IProductInventoryAppService productInventoryAppService)
        {
            _productInventoryAppService = productInventoryAppService;
        }

        [HttpPost]
        public async Task<BaseResponseDto<ProductInventoryResponseDto>> CreateProductInventory([FromBody] ProductInventoryRequestDto productInventoryRequestDto)
        {
           return await _productInventoryAppService.CreateProductInventory(productInventoryRequestDto);
        }
    }
}
