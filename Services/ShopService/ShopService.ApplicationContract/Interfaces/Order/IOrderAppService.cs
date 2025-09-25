using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Order;

namespace ShopService.ApplicationContract.Interfaces.Order
{
    public interface IOrderAppService
    {
        Task<BaseResponseDto<OrderDto>> CreateOrder(OrderDto orderDto);
        Task<BaseResponseDto<List<ShowOrderDto>>> GetAllOrders();
    }
}
