using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.Category;
using ApiCallService.ApplicationContract.Interfaces.Internal.Category;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
namespace ApiCallService.Application.Services.Internal.Category
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CategoryAppService(HttpClient client,IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            _httpContextAccessor = httpContextAccessor;
        }

        #region Create
        public async Task<BaseResponseDto<CategoryDto>> CreateCategoryAsync(CategoryDto categoryDto)
        {
            var output = new BaseResponseDto<CategoryDto>
            {
                Message = "خطا در درج دسته بندی",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if(token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.PostAsJsonAsync("https://localhost:44358/Category/Create", categoryDto);
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadFromJsonAsync<BaseResponseDto<CategoryDto>>();
            if (content != null)
            {
                return content;
            }
            return output;
        }
        #endregion

        #region Delete
        public async Task<BaseResponseDto<CategoryDto>> DeleteCategoryAsync(int id)
        {
            var output = new BaseResponseDto<CategoryDto>
            {
                Message = "خطا در حذف دسته بندی",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            }; var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.DeleteAsync($"https://localhost:44358/Category/Delete/{id}");
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadFromJsonAsync<BaseResponseDto<CategoryDto>>();
            if (content != null)
            {
                return content;
            }
            return output;
        }
        #endregion

        #region Edit
        public async Task<BaseResponseDto<CategoryDto>> EditCategoryAsync(int id, CategoryDto categoryDto)
        {
            var output = new BaseResponseDto<CategoryDto>
            {
                Message = "خطا در به روز رسانی دسته بندی",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.PostAsJsonAsync($"https://localhost:44358/Category/Edit/{id}", categoryDto);
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadFromJsonAsync<BaseResponseDto<CategoryDto>>();
            if (content != null)
            {
                return content;
            }
            return output;
        }
        #endregion

        #region GetAll
        public async Task<BaseResponseDto<List<CategoryDto>>> GetAllCategoriesAsync()
        {
            var output = new BaseResponseDto<List<CategoryDto>>
            {
                Message = "خطا در بازیابی دسته‌بندی ها",
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.GetAsync("https://localhost:44358/Category/GetAll");
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadAsStringAsync();
            var deserialize = JsonConvert.DeserializeObject<BaseResponseDto<List<CategoryDto>>>(content);
            if (deserialize != null)
            {
                return deserialize;
            }
            return output;
        }
        #endregion

        #region Get
        public async Task<BaseResponseDto<CategoryDto>> GetCategoryByIdAsync(int id)
        {
            var output = new BaseResponseDto<CategoryDto>
            {
                Message = "خطا در بازیابی دسته‌بندی",
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.GetAsync($"https://localhost:44358/Category/GetById/{id}");
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadAsStringAsync();
            var deserialize = JsonConvert.DeserializeObject<BaseResponseDto<CategoryDto>>(content);
            if (deserialize != null)
            {
                return deserialize;
            }
            return output;
        }
        #endregion

    }
}
