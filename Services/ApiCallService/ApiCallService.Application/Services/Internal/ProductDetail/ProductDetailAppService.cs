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
        public async Task<BaseResponseDto<ProductDetailDto>> CreateProductDetailAsync(ProductDetailDto ProductDetailDto)
        {
            var output = new BaseResponseDto<ProductDetailDto>
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
            var content = await response.Content.ReadFromJsonAsync<BaseResponseDto<ProductDetailDto>>();
            if (content != null)
            {
                output.Message = content.Message;
                output.Success = content.Success;
                output.StatusCode = content.Success ? content.StatusCode : content.StatusCode;
            }
            return output;
        }
        #endregion

        #region Edit
        public async Task<BaseResponseDto<ProductDetailDto>> EditProductDetailAsync(int id, ProductDetailDto ProductDetailDto)
        {
            var output = new BaseResponseDto<ProductDetailDto>
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
            var content = await response.Content.ReadFromJsonAsync<BaseResponseDto<ProductDetailDto>>();
            if (content != null)
            {
                output.Message = content.Message;
                output.Success = content.Success;
                output.StatusCode = content.Success ? content.StatusCode : content.StatusCode;
            }
            return output;
        }
        #endregion

        #region GetAll
        public async Task<BaseResponseDto<List<ProductDetailDto>>> GetAllProductDetailsAsync()

        {
            var output = new BaseResponseDto<List<ProductDetailDto>>
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
            var deserialize = JsonConvert.DeserializeObject<BaseResponseDto<List<ProductDetailDto>>>(content);
            if (deserialize != null)
            {
                output.Message = deserialize.Message;
                output.Success = deserialize.Success;
                output.StatusCode = deserialize.Success ? deserialize.StatusCode : deserialize.StatusCode;
                output.Data = deserialize.Data;
            }
            return output;
        }
        #endregion

        #region Get
        public async Task<BaseResponseDto<ProductDetailDto>> GetProductDetailByIdAsync(int id)
        {
            var output = new BaseResponseDto<ProductDetailDto>
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
            var deserialize = JsonConvert.DeserializeObject<BaseResponseDto<ProductDetailDto>>(content);
            if (deserialize != null)
            {
                output.Message = deserialize.Message;
                output.Success = deserialize.Success;
                output.StatusCode = deserialize.Success ? deserialize.StatusCode : deserialize.StatusCode;
                output.Data = deserialize.Data;
            }
            return output;

        }
        #endregion

        #region Delete
        public async Task<BaseResponseDto<ProductDetailDto>> DeleteProductDetailAsync(int id)
        {
            var output = new BaseResponseDto<ProductDetailDto>
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
            var content = await response.Content.ReadFromJsonAsync<BaseResponseDto<ProductDetailDto>>();
            if (content != null)
            {
                output.Message = content.Message;
                output.Success = content.Success;
                output.StatusCode = content.Success ? content.StatusCode : content.StatusCode;
            }
            return output;
        }
        #endregion
    }
}
