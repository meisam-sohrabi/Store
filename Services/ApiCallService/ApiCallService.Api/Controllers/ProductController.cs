using First.ApplicationContract.DTO.Base;
using First.ApplicationContract.DTO.Internal.Product;
using First.InfrastructureContract.Interfaces.Internal.Product;
using Microsoft.AspNetCore.Mvc;

namespace First.Api.Controller
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductApi _productApi;

        public ProductController(IProductApi productApi)
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
