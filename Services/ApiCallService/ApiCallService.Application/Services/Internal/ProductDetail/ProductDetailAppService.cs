using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.ProductDetail;
using ApiCallService.ApplicationContract.Interfaces.Internal.ProductDetail;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ApiCallService.Application.Services.Internal.ProductDetail
{
    public class ProductDetailAppService : IProductDetailAppService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductDetailAppService(HttpClient client, IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            _httpContextAccessor = httpContextAccessor;
        }

        #region Create
        public async Task<BaseResponseDto<ProductDetailResponseDto>> CreateProductDetailAsync(ProductDetailRequestDto ProductDetailDto)
        {
            var output = new BaseResponseDto<ProductDetailResponseDto>
            {
                Message = "خطا در درج جزئیات محصول",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.PostAsJsonAsync("https://localhost:44358/ProductDetail/Create", ProductDetailDto);
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadFromJsonAsync<BaseResponseDto<ProductDetailResponseDto>>();
            if (content != null)
            {
                return content;
            }
            return output;
        }
        #endregion

        #region Edit
        public async Task<BaseResponseDto<ProductDetailResponseDto>> EditProductDetailAsync(int id, ProductDetailRequestDto ProductDetailDto)
        {
            var output = new BaseResponseDto<ProductDetailResponseDto>
            {
                Message = "خطا در به روز رسانی جزئیات محصول",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.PostAsJsonAsync($"https://localhost:44358/ProductDetail/Edit/{id}", ProductDetailDto);
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadFromJsonAsync<BaseResponseDto<ProductDetailResponseDto>>();
            if (content != null)
            {
                return content;

            }
            return output;
        }
        #endregion

        #region GetAll
        public async Task<BaseResponseDto<List<ProductDetailResponseDto>>> GetAllProductDetailsAsync()

        {
            var output = new BaseResponseDto<List<ProductDetailResponseDto>>
            {
                Message = "خطا در بازیابی  جزئیات محصولات ",
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.GetAsync("https://localhost:44358/ProductDetail/GetAll");
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadAsStringAsync();
            var deserialize = JsonConvert.DeserializeObject<BaseResponseDto<List<ProductDetailResponseDto>>>(content);
            if (deserialize != null)
            {
                return deserialize;

            }
            return output;
        }
        #endregion

        #region Get
        public async Task<BaseResponseDto<ProductDetailResponseDto>> GetProductDetailByIdAsync(int id)
        {
            var output = new BaseResponseDto<ProductDetailResponseDto>
            {
                Message = "خطا در بازیابی جزئیات محصول",
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.GetAsync($"https://localhost:44358/ProductDetail/GetById/{id}");
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadAsStringAsync();
            var deserialize = JsonConvert.DeserializeObject<BaseResponseDto<ProductDetailResponseDto>>(content);
            if (deserialize != null)
            {
                return deserialize;

            }
            return output;

        }
        #endregion

        #region Delete
        public async Task<BaseResponseDto<ProductDetailResponseDto>> DeleteProductDetailAsync(int id)
        {
            var output = new BaseResponseDto<ProductDetailResponseDto>
            {
                Message = "خطا در حذف برند جزئیات محصول",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.DeleteAsync($"https://localhost:44358/ProductDetail/Delete/{id}");
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadFromJsonAsync<BaseResponseDto<ProductDetailResponseDto>>();
            if (content != null)
            {
                return content;
            }
            return output;
        }
        #endregion
    }
}
