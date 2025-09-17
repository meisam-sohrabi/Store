using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Second.Application.Services.Product;
using Second.ApplicationContract.DTO.Base;
using Second.ApplicationContract.DTO.Product;

namespace Second.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductAppService _productAppService;

        public ProductController(ProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductDto>> Create([FromBody]ProductDto productDto)
        {
            return await _productAppService.CreateProduct(productDto);

        }

        [HttpPost("Edit/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductDto>> Edit([FromRoute]int id,[FromBody]ProductDto productDto)
        {
            return await _productAppService.EditProduct(id,productDto);
        }

        [HttpGet("GetAll")]
        public async Task<BaseResponseDto<List<ProductDto>>> GetAll()
        {
            return await _productAppService.GetAllProduct();
        }

        [HttpGet("GetById/{id}")]
        public async Task<BaseResponseDto<ProductDto>> GetById([FromRoute]int id)
        {
            return await _productAppService.GetProduct(id);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductDto>> Delete([FromRoute]int id)
        {
            return await _productAppService.DeleteProduct(id);
        }
    }
}
