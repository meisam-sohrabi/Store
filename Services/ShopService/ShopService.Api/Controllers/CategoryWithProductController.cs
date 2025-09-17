using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Second.Application.Services.CategoryWithProduct;
using Second.ApplicationContract.DTO.Base;
using Second.ApplicationContract.DTO.CategoryWithProduct;

namespace Second.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryWithProductController : ControllerBase
    {
        private readonly CategoryWithProductAppService _categoryWithProductAppService;

        public CategoryWithProductController(CategoryWithProductAppService categoryWithProductAppService)
        {
            _categoryWithProductAppService = categoryWithProductAppService;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<CategoryWithProductDto>> Create (CategoryWithProductDto categoryWithProductDto)
        {
            return await _categoryWithProductAppService.CreateCategoryWithProduct(categoryWithProductDto);
        }
    }
}
