using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.CategoryWithProduct;
using ApiCallService.ApplicationContract.Interfaces.Internal.CategoryWithProduct;
using Microsoft.AspNetCore.Mvc;

namespace ApiCallService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryWithProductController : ControllerBase
    {
        private readonly ICategoryWithProductApi _categoryWithProductApi;

        public CategoryWithProductController(ICategoryWithProductApi categoryWithProductApi)
        {
            _categoryWithProductApi = categoryWithProductApi;
        }

        [HttpPost("Create")]
        public async Task<BaseResponseDto<CategoryWithProductDto>> Create(CategoryWithProductDto categoryWithProductDto)
        {
            return await _categoryWithProductApi.CreateCategoryWithProduct(categoryWithProductDto);
        }
    }
}
