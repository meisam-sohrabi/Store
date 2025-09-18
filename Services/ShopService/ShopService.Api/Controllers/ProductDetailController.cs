using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopService.Application.Services.ProductDetail;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.ProductDetail;

namespace ShopService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly ProductDetailAppService _productDetailAppService;

        public ProductDetailController(ProductDetailAppService productDetailAppService)
        {
            _productDetailAppService = productDetailAppService;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductDetailDto>> Create([FromBody] ProductDetailDto productDetailDto)
        {
            return await _productDetailAppService.CreateDetail(productDetailDto);

        }

        [HttpPost("Edit/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductDetailDto>> Edit([FromRoute] int id, [FromBody] ProductDetailDto productDetailDto)
        {
            return await _productDetailAppService.EditDetail(id, productDetailDto);
        }

        [HttpGet("GetAll")]
        public async Task<BaseResponseDto<List<ProductDetailDto>>> GetAll()
        {
            return await _productDetailAppService.GetAllDetails();
        }

        [HttpGet("GetById/{id}")]
        public async Task<BaseResponseDto<ProductDetailDto>> GetById([FromRoute] int id)
        {
            return await _productDetailAppService.GetDetail(id);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductDetailDto>> Delete([FromRoute] int id)
        {
            return await _productDetailAppService.DeleteDetail(id);
        }
    }
}
