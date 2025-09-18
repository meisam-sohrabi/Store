using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.Transaction;
using ApiCallService.ApplicationContract.Interfaces.Internal.CategoryWithProduct;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ApiCallService.Application.Services.Internal.Transactions.Product
{
    public class ProductTransactionsAppService : IProductTransactionAppService
    {
        private readonly HttpClient _client;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductTransactionsAppService(HttpClient client, IHttpContextAccessor httpContextAccessor)
        {
            _client = client;
            _httpContextAccessor = httpContextAccessor;
        }

        #region Create
        public async Task<BaseResponseDto<ProductTransactionDto>> ProductTransaction (ProductTransactionDto productTransactionDto)
        {
            var output = new BaseResponseDto<ProductTransactionDto>
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
            var response = await _client.PostAsJsonAsync("https://localhost:44358/Product/ProductTransaction", productTransactionDto);
            if (!response.IsSuccessStatusCode)
            {
                output.Message = $"خطای سرور: {response.StatusCode}";
                output.StatusCode = response.StatusCode;
                output.Success = false;
            }
            var content = await response.Content.ReadFromJsonAsync<BaseResponseDto<ProductTransactionDto>>();
            if (content != null)
            {
                return content;
            }
            return output;
        }
        #endregion

    }
}
