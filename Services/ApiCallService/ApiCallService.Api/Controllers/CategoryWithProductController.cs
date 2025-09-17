using First.ApplicationContract.DTO.Base;
using First.ApplicationContract.DTO.Internal.CategoryWithProduct;
using First.InfrastructureContract.Interfaces.Internal.CategoryWithProduct;
using Microsoft.AspNetCore.Mvc;

namespace First.Api.Controller
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
