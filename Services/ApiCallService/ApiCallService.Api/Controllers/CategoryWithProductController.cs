using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.Transaction;
using ApiCallService.ApplicationContract.Interfaces.Internal.CategoryWithProduct;
using Microsoft.AspNetCore.Mvc;

namespace ApiCallService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryWithProductController : ControllerBase
    {
        private readonly IProductTransactionAppService _categoryWithProductApi;

        public CategoryWithProductController(IProductTransactionAppService categoryWithProductApi)
        {
            _categoryWithProductApi = categoryWithProductApi;
        }

        [HttpPost("Create")]
        public async Task<BaseResponseDto<ProductTransactionDto>> Create(ProductTransactionDto productTransactionDto)
        {
            return await _categoryWithProductApi.ProductTransaction(productTransactionDto);
        }
    }
}
