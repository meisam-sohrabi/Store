using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.ProductDetail;
using ShopService.ApplicationContract.Interfaces.ProductDetail;

namespace ShopService.Api.Controllers
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
        public async Task<BaseResponseDto<ProductDetailResponseDto>> Create([FromBody] ProductDetailRequestDto productDetailDto)
        {
            return await _productDetailAppService.CreateProductDetail(productDetailDto);

        }

        [HttpPost("Edit/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductDetailResponseDto>> Edit([FromRoute] int id, [FromBody] ProductDetailRequestDto productDetailDto)
        {
            return await _productDetailAppService.EditProductDetail(id, productDetailDto);
        }

        [HttpGet("GetAll")]
        public async Task<BaseResponseDto<List<ProductDetailResponseDto>>> GetAll()
        {
            return await _productDetailAppService.GetAllProductDetails();
        }

        [HttpGet("GetById/{id}")]
        public async Task<BaseResponseDto<ProductDetailResponseDto>> GetById([FromRoute] int id)
        {
            return await _productDetailAppService.GetProductDetail(id);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductDetailResponseDto>> Delete([FromRoute] int id)
        {
            return await _productDetailAppService.DeleteProductDetail(id);
        }
    }
}
