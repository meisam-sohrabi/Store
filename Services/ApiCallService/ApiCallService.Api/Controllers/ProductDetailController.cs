using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.ProductDetail;
using ApiCallService.ApplicationContract.Interfaces.Internal.ProductDetail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiCallService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailAppService _productDetailAppService;

        public ProductDetailController(IProductDetailAppService productDetailAppService)
        {
            _productDetailAppService = productDetailAppService;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductDetailDto>> Create([FromBody] ProductDetailDto productDetailDto)
        {
            return await _productDetailAppService.CreateProductDetailAsync(productDetailDto);

        }

        [HttpPost("Edit/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductDetailDto>> Edit([FromRoute] int id, [FromBody] ProductDetailDto productDetailDto)
        {
            return await _productDetailAppService.EditProductDetailAsync(id, productDetailDto);
        }

        [HttpGet("GetAll")]
        public async Task<BaseResponseDto<List<ProductDetailDto>>> GetAll()
        {
            return await _productDetailAppService.GetAllProductDetailsAsync();
        }

        [HttpGet("GetById/{id}")]
        public async Task<BaseResponseDto<ProductDetailDto>> GetById([FromRoute] int id)
        {
            return await _productDetailAppService.GetProductDetailByIdAsync(id);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductDetailDto>> Delete([FromRoute] int id)
        {
            return await _productDetailAppService.DeleteProductDetailAsync(id);
        }
    }
}
