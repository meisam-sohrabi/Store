using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.ProductPrice;
using ShopService.ApplicationContract.Interfaces.ProductPrice;

namespace ShopService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductPriceController : ControllerBase
    {
        private readonly IProductPriceAppService _productPriceAppService;

        public ProductPriceController(IProductPriceAppService productPriceAppService)
        {
            _productPriceAppService = productPriceAppService;
        }


        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductPriceResponseDto>> Create([FromBody] ProductPriceRequestDto productPriceDto)
        {
            return await _productPriceAppService.CreateProductPrice(productPriceDto);

        }

        [HttpPost("Edit/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductPriceResponseDto>> Edit([FromRoute] int id, [FromBody] ProductPriceRequestDto productPriceDto)
        {
            return await _productPriceAppService.EditProductPrice(id, productPriceDto);
        }

        [HttpGet("GetAll")]
        public async Task<BaseResponseDto<List<ProductPriceResponseDto>>> GetAll()
        {
            return await _productPriceAppService.GetAllProductPrice();
        }

        [HttpGet("GetById/{id}")]
        public async Task<BaseResponseDto<ProductPriceResponseDto>> GetById([FromRoute] int id)
        {
            return await _productPriceAppService.GetProductPrice(id);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductPriceResponseDto>> Delete([FromRoute] int id)
        {
            return await _productPriceAppService.DeleteProductPrice(id);
        }
    }
}
