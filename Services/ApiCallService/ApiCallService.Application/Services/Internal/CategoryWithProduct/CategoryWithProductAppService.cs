using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.CategoryWithProduct;
using ApiCallService.ApplicationContract.Interfaces.Internal.CategoryWithProduct;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ApiCallService.Application.Services.Internal.CategoryWithProduct
{
    public class CategoryWithProductAppService : ICategoryWithProductAppService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryWithProductAppService(HttpClient client,IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            _httpContextAccessor = httpContextAccessor;
        }

        #region Create
        public async Task<BaseResponseDto<CategoryWithProductDto>> CreateCategoryWithProduct(CategoryWithProductDto categoryWithProductDto)
        {
            var output = new BaseResponseDto<CategoryWithProductDto>
            {
                Message = "خطا در درج دسته بندی و محصول",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.PostAsJsonAsync("https://localhost:44358/CategoryWithProduct/Create", categoryWithProductDto);
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
            }
            var content = await response.Content.ReadFromJsonAsync<BaseResponseDto<CategoryWithProductDto>>();
            if (content != null)
            {
                return content;
            }
            return output;
        }
        #endregion

    }
}
