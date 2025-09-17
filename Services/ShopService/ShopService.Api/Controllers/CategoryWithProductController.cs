using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopService.Application.Services.CategoryWithProduct;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.CategoryWithProduct;

namespace ShopService.Api.Controllers
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
