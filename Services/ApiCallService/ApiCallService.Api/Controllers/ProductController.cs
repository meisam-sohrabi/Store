using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.Product;
using ApiCallService.ApplicationContract.Interfaces.Internal.Product;
using Microsoft.AspNetCore.Mvc;

namespace ApiCallService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productApi;

        public ProductController(IProductAppService productApi)
        {
            _productApi = productApi;
        }

        [HttpPost("Create")]
        public async Task<BaseResponseDto<ProductDto>> Create([FromBody] ProductDto productDto)
        {
            return await _productApi.CreateProductAsync(productDto);

        }

        [HttpPost("Edit/{id}")]
        public async Task<BaseResponseDto<ProductDto>> Edit([FromRoute] int id, [FromBody] ProductDto productDto)
        {
            return await _productApi.EditProductAsync(id, productDto);
        }

        [HttpGet("GetAll")]
        public async Task<BaseResponseDto<List<ProductDto>>> GetAll()
        {
            return await _productApi.GetAllProductsAsync();
        }

        [HttpGet("GetById/{id}")]
        public async Task<BaseResponseDto<ProductDto>> GetById([FromRoute] int id)
        {
            return await _productApi.GetProductByIdAsync(id);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<BaseResponseDto<ProductDto>> Delete([FromRoute] int id)
        {
            return await _productApi.DeleteProductAsync(id);
        }
    }
}
