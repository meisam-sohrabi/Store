using System.Net;

namespace ShopService.ApplicationContract.DTO.Base
{
    public class BaseResponseDto<T>
    {
        public string? Message { get; set; }
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public T? Data { get; set; } 
    }
}
