using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Order;
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

        [HttpPost("Order")]
        public async Task<BaseResponseDto<OrderDto>> CreateOrder(OrderDto orderDto)
        {
            return await _orderAppService.CreateOrder(orderDto);
        }

        [HttpGet("GetAllOrders")]
        public async Task<BaseResponseDto<List<ShowOrderDto>>> GetAllOrder()
        {
            return await _orderAppService.GetAllOrders();
        }


    }
}
