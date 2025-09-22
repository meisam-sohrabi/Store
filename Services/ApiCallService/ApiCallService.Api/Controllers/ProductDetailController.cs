using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.ProductDetail;
using ApiCallService.ApplicationContract.Interfaces.Internal.ProductDetail;
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
        public async Task<BaseResponseDto<ProductDetailResponseDto>> Create([FromBody] ProductDetailRequestDto productDetailDto)
        {
            return await _productDetailAppService.CreateProductDetailAsync(productDetailDto);

        }

        [HttpPost("Edit/{id}")]
        public async Task<BaseResponseDto<ProductDetailResponseDto>> Edit([FromRoute] int id, [FromBody] ProductDetailRequestDto productDetailDto)
        {
            return await _productDetailAppService.EditProductDetailAsync(id, productDetailDto);
        }

        [HttpGet("GetAll")]
        public async Task<BaseResponseDto<List<ProductDetailResponseDto>>> GetAll()
        {
            return await _productDetailAppService.GetAllProductDetailsAsync();
        }

        [HttpGet("GetById/{id}")]
        public async Task<BaseResponseDto<ProductDetailResponseDto>> GetById([FromRoute] int id)
        {
            return await _productDetailAppService.GetProductDetailByIdAsync(id);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<BaseResponseDto<ProductDetailResponseDto>> Delete([FromRoute] int id)
        {
            return await _productDetailAppService.DeleteProductDetailAsync(id);
        }
    }
}
