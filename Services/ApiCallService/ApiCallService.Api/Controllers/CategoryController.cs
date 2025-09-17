using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.Category;
using ApiCallService.ApplicationContract.Interfaces.Internal.Category;
using Microsoft.AspNetCore.Mvc;

namespace ApiCallService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApi _categoryApi;

        public CategoryController(ICategoryApi categoryApi)
        {
            _categoryApi = categoryApi;
        }
        [HttpPost("Create")]
        public async Task<BaseResponseDto<CategoryDto>> Create([FromBody] CategoryDto categoryDto)
        {
            return await _categoryApi.CreateCategoryAsync(categoryDto);

        }

        [HttpPost("Edit/{id}")]
        public async Task<BaseResponseDto<CategoryDto>> Edit([FromRoute] int id, [FromBody] CategoryDto categoryDto)
        {
            return await _categoryApi.EditCategoryAsync(id, categoryDto);
        }

        [HttpGet("GetAll")]
        public async Task<BaseResponseDto<List<CategoryDto>>> GetAll()
        {
            return await _categoryApi.GetAllCategoriesAsync();
        }

        [HttpGet("GetById/{id}")]
        public async Task<BaseResponseDto<CategoryDto>> GetById([FromRoute] int id)
        {
            return await _categoryApi.GetCategoryByIdAsync(id);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<BaseResponseDto<CategoryDto>> Delete([FromRoute] int id)
        {
            return await _categoryApi.DeleteCategoryAsync(id);
        }
    }
}
