using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.ProductBrand;
using ApiCallService.ApplicationContract.Interfaces.Internal.ProductBrand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiCallService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductBrandController : ControllerBase
    {
        private readonly IProductBrandAppService _productBrandAppService;

        public ProductBrandController(IProductBrandAppService productBrandAppService)
        {
            _productBrandAppService = productBrandAppService;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductBrandDto>> Create([FromBody] ProductBrandDto productDto)
        {
            return await _productBrandAppService.CreateProductBrandAsync(productDto);

        }

        [HttpPost("Edit/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductBrandDto>> Edit([FromRoute] int id, [FromBody] ProductBrandDto productDto)
        {
            return await _productBrandAppService.EditProductBrandAsync(id, productDto);
        }

        [HttpGet("GetAll")]
        public async Task<BaseResponseDto<List<ProductBrandDto>>> GetAll()
        {
            return await _productBrandAppService.GetAllProductBrandsAsync();
        }

        [HttpGet("GetById/{id}")]
        public async Task<BaseResponseDto<ProductBrandDto>> GetById([FromRoute] int id)
        {
            return await _productBrandAppService.GetProductBrandByIdAsync(id);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductBrandDto>> Delete([FromRoute] int id)
        {
            return await _productBrandAppService.DeleteProductBrandAsync(id);
        }
    }
}
