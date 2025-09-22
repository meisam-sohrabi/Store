using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.ProductBrand;
using ApiCallService.ApplicationContract.Interfaces.Internal.ProductBrand;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ApiCallService.Application.Services.Internal.ProductBrand
{
    public class ProductBrandAppService : IProductBrandAppService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductBrandAppService(HttpClient client, IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            _httpContextAccessor = httpContextAccessor;
        }

        #region Create
        public async Task<BaseResponseDto<ProductBrandDto>> CreateProductBrandAsync(ProductBrandDto ProductBrandDto)
        {
            var output = new BaseResponseDto<ProductBrandDto>
            {
                Message = "خطا در درج برند برند محصول",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.PostAsJsonAsync("https://localhost:44358/ProductBrand/Create", ProductBrandDto);
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadFromJsonAsync<BaseResponseDto<ProductBrandDto>>();
            if (content != null)
            {
                return content;
            }
            return output;
        }
        #endregion

        #region Edit
        public async Task<BaseResponseDto<ProductBrandDto>> EditProductBrandAsync(int id, ProductBrandDto productBrandDto)
        {
            var output = new BaseResponseDto<ProductBrandDto>
            {
                Message = "خطا در به روز رسانی برند محصول",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.PostAsJsonAsync($"https://localhost:44358/ProductBrand/Edit/{id}", productBrandDto);
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadFromJsonAsync<BaseResponseDto<ProductBrandDto>>();
            if (content != null)
            {
                return content;
            }
            return output;
        }
        #endregion

        #region GetAll
        public async Task<BaseResponseDto<List<ProductBrandDto>>> GetAllProductBrandsAsync()

        {
            var output = new BaseResponseDto<List<ProductBrandDto>>
            {
                Message = "خطا در بازیابی برند محصولات ها",
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.GetAsync("https://localhost:44358/ProductBrand/GetAll");
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadAsStringAsync();
            var deserialize = JsonConvert.DeserializeObject<BaseResponseDto<List<ProductBrandDto>>>(content);
            if (deserialize != null)
            {
                return deserialize;
            }
            return output;
        }
        #endregion

        #region Get
        public async Task<BaseResponseDto<ProductBrandDto>> GetProductBrandByIdAsync(int id)
        {
            var output = new BaseResponseDto<ProductBrandDto>
            {
                Message = "خطا در بازیابی برند محصول",
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.GetAsync($"https://localhost:44358/ProductBrand/GetById/{id}");
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadAsStringAsync();
            var deserialize = JsonConvert.DeserializeObject<BaseResponseDto<ProductBrandDto>>(content);
            if (deserialize != null)
            {
                   return deserialize;
            }
            return output;

        }
        #endregion

        #region Delete
        public async Task<BaseResponseDto<ProductBrandDto>> DeleteProductBrandAsync(int id)
        {
            var output = new BaseResponseDto<ProductBrandDto>
            {
                Message = "خطا در حذف برند محصول",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.DeleteAsync($"https://localhost:44358/ProductBrand/Delete/{id}");
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadFromJsonAsync<BaseResponseDto<ProductBrandDto>>();
            if (content != null)
            {
                return content;
            }
            return output;
        }
        #endregion
    }
}
