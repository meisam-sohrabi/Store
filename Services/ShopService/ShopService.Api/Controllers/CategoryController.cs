using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Second.Application.Services.Category;
using Second.Application.Services.Permission;
using Second.ApplicationContract.DTO.Base;
using Second.ApplicationContract.DTO.Category;
using Second.ApplicationContract.Interfaces;
using System.Security.Claims;
namespace Second.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryAppService _categoryAppService;
        private readonly IUserAppService _userAppService;

        public CategoryController(CategoryAppService categoryAppService,IUserAppService userAppService)
        {
            _categoryAppService = categoryAppService;
            _userAppService = userAppService;
        }

        [HttpPost("Create")]
        [Authorize(Roles ="admin")]
        [Permission]
        public async Task<BaseResponseDto<CategoryDto>> Create([FromBody]CategoryDto categoryDto)
        {
            _userAppService.GetCurrentUser(ClaimTypes.NameIdentifier);
            return await _categoryAppService.CreateCategory(categoryDto);

        }

        [HttpPost("Edit/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<CategoryDto>> Edit([FromRoute]int id,[FromBody]CategoryDto categoryDto)
        {
            return await _categoryAppService.EditCategory(id,categoryDto);
        }

        [HttpGet("GetAll")]
        public async Task<BaseResponseDto<List<CategoryDto>>> GetAll()
        {
            return await _categoryAppService.GetAllCategories();
        }

        [HttpGet("GetById/{id}")]
        public async Task<BaseResponseDto<CategoryDto>> GetById([FromRoute]int id)
        {
            return await _categoryAppService.GetCategory(id);
        }

        [HttpDelete("Delete/{id}")]
        [Authorize(Roles = "admin")]
        public async Task<BaseResponseDto<CategoryDto>> Delete([FromRoute]int id)
        {
            return await _categoryAppService.DeleteCategory(id);
        }
    }
}
