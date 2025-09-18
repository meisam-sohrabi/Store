using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopService.Application.Services.Permission;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Category;
using ShopService.ApplicationContract.Interfaces.Category;
namespace ShopService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        [HttpPost("Create")]
        [Authorize(Roles = "admin")]
        [Permission]
        public async Task<BaseResponseDto<CategoryDto>> Create([FromBody] CategoryDto categoryDto)
        {
            return await _categoryAppService.CreateCategory(categoryDto);

        }

        [HttpPost("Edit/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<CategoryDto>> Edit([FromRoute] int id, [FromBody] CategoryDto categoryDto)
        {
            return await _categoryAppService.EditCategory(id, categoryDto);
        }

        [HttpGet("GetAll")]
        public async Task<BaseResponseDto<List<CategoryDto>>> GetAll()
        {
            return await _categoryAppService.GetAllCategories();
        }

        [HttpGet("GetById/{id}")]
        public async Task<BaseResponseDto<CategoryDto>> GetById([FromRoute] int id)
        {
            return await _categoryAppService.GetCategory(id);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<CategoryDto>> Delete([FromRoute] int id)
        {
            return await _categoryAppService.DeleteCategory(id);
        }
    }
}
