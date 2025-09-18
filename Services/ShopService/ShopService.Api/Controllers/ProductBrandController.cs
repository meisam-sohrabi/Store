using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopService.Application.Services.ProductBrand;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.ProductBrand;

namespace ShopService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductBrandController : ControllerBase
    {
        private readonly ProductBrandAppService _productBrandAppService;

        public ProductBrandController(ProductBrandAppService productBrandAppService)
        {
            _productBrandAppService = productBrandAppService;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductBrandDto>> Create([FromBody] ProductBrandDto productDto)
        {
            return await _productBrandAppService.CreateBrand(productDto);

        }

        [HttpPost("Edit/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductBrandDto>> Edit([FromRoute] int id, [FromBody] ProductBrandDto productDto)
        {
            return await _productBrandAppService.EditBrand(id, productDto);
        }

        [HttpGet("GetAll")]
        public async Task<BaseResponseDto<List<ProductBrandDto>>> GetAll()
        {
            return await _productBrandAppService.GetAllBrands();
        }

        [HttpGet("GetById/{id}")]
        public async Task<BaseResponseDto<ProductBrandDto>> GetById([FromRoute] int id)
        {
            return await _productBrandAppService.GetBrand(id);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductBrandDto>> Delete([FromRoute] int id)
        {
            return await _productBrandAppService.DeleteBrand(id);
        }
    }
}
