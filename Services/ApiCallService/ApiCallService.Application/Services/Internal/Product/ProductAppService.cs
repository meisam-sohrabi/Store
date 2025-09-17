using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.Product;
using ApiCallService.ApplicationContract.Interfaces.Internal.Product;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
namespace ApiCallService.Application.Services.Internal.Product
{
    public class ProductAppService : IProductApi
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductAppService(HttpClient client,IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            _httpContextAccessor = httpContextAccessor;
        }

        #region Create
        public async Task<BaseResponseDto<ProductDto>> CreateProductAsync(ProductDto productDto)
        {
            var output = new BaseResponseDto<ProductDto>
            {
                Message = "خطا در درج محصول",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.PostAsJsonAsync("https://localhost:44358/Product/Create", productDto);
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadFromJsonAsync<BaseResponseDto<ProductDto>>();
            if (content != null)
            {
                output.Message = content.Message;
                output.Success = content.Success;
                output.StatusCode = content.Success ? content.StatusCode : content.StatusCode;
            }
            return output;
        }
        #endregion

        #region Delete
        public async Task<BaseResponseDto<ProductDto>> DeleteProductAsync(int id)
        {
            var output = new BaseResponseDto<ProductDto>
            {
                Message = "خطا در حذف محصول",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.DeleteAsync($"https://localhost:44358/Product/Delete/{id}");
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadFromJsonAsync<BaseResponseDto<ProductDto>>();
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
        public async Task<BaseResponseDto<ProductDto>> EditProductAsync(int id, ProductDto productDto)
        {
            var output = new BaseResponseDto<ProductDto>
            {
                Message = "خطا در بروزرسانی محصول",
                Success = false,
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.PostAsJsonAsync($"https://localhost:44358/Product/Edit/{id}", productDto);
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadFromJsonAsync<BaseResponseDto<ProductDto>>();
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
        public async Task<BaseResponseDto<List<ProductDto>>> GetAllProductsAsync()

        {
            var output = new BaseResponseDto<List<ProductDto>>
            {
                Message = "خطا در بازیابی محصولات",
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.GetAsync("https://localhost:44358/Product/GetAll");
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadAsStringAsync();
            var deserialize = JsonConvert.DeserializeObject<BaseResponseDto<List<ProductDto>>>(content);
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
        public async Task<BaseResponseDto<ProductDto>> GetProductByIdAsync(int id)
        {
            var output = new BaseResponseDto<ProductDto>
            {
                Message = "خطا در بازیابی محصول",
                StatusCode = HttpStatusCode.BadRequest
            };
            var token = _httpContextAccessor.HttpContext?.Request.Headers["Authorization"].ToString();
            if (token != null)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            var response = await _client.GetAsync($"https://localhost:44358/Product/GetById/{id}");
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
                return output;
            }
            var content = await response.Content.ReadAsStringAsync();
            var deserialize = JsonConvert.DeserializeObject<BaseResponseDto<ProductDto>>(content);
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


    }
}
