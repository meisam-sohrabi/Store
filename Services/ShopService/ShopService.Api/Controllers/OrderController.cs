using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopService.Application.Services.PermissionAttribute;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Order;
using ShopService.ApplicationContract.DTO.Transaction;
using ShopService.ApplicationContract.Interfaces.Order;

namespace ShopService.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderAppService _orderAppService;

        public OrderController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        [HttpPost("OrderTransaction")]
        //[Authorize(Roles = "user")]
        //[Permission]
        public async Task<BaseResponseDto<OrderTransactionDto>> OrderTransaction([FromBody] OrderTransactionDto orderTransactionDto, [FromQuery] int productDetailId)
        {
            return await _orderAppService.OrderTransaction(orderTransactionDto, productDetailId);
        }

        [HttpGet("GetAllOrders")]
        public async Task<BaseResponseDto<List<OrderResponseDto>>> GetAllOrder()
        {
            return await _orderAppService.GetAllOrders();
        }


    }
}
