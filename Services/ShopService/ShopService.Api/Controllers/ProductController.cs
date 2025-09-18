using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopService.Application.Services.Permission;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Product;
using ShopService.ApplicationContract.DTO.Transaction;
using ShopService.ApplicationContract.Interfaces.Product;
using ShopService.ApplicationContract.Interfaces.Transactions.Product;

namespace ShopService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductAppService _productAppService;
        private readonly IProductTransactionAppService _productTransactionAppService;

        public ProductController(IProductAppService productAppService, IProductTransactionAppService productTransactionAppService)
        {
            _productAppService = productAppService;
            _productTransactionAppService = productTransactionAppService;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductDto>> Create([FromBody] ProductDto productDto)
        {
            return await _productAppService.CreateProduct(productDto);

        }

        [HttpPost("Edit/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductDto>> Edit([FromRoute] int id, [FromBody] ProductDto productDto)
        {
            return await _productAppService.EditProduct(id, productDto);
        }

        [HttpGet("GetAll")]
        public async Task<BaseResponseDto<List<ProductDto>>> GetAll()
        {
            return await _productAppService.GetAllProduct();
        }

        [HttpGet("GetById/{id}")]
        public async Task<BaseResponseDto<ProductDto>> GetById([FromRoute] int id)
        {
            return await _productAppService.GetProduct(id);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<ProductDto>> Delete([FromRoute] int id)
        {
            return await _productAppService.DeleteProduct(id);
        }

        [HttpPost("ProductTransaction")]
        [Authorize(Roles = "admin")]
        [Permission]
        public async Task<BaseResponseDto<ProductTransactionDto>> ProductTransaction([FromBody] ProductTransactionDto productTransactionDto)
        {
            return await _productTransactionAppService.ProductTransaction(productTransactionDto);
        }
    }
}
