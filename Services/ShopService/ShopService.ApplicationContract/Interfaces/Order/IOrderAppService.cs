using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Order;
using ShopService.ApplicationContract.DTO.Transaction;

namespace ShopService.ApplicationContract.Interfaces.Order
{
    public interface IOrderAppService
    {
        Task<BaseResponseDto<OrderTransactionDto>> OrderTransaction(OrderTransactionDto orderTransactionDto,int productDetailId);
        Task<BaseResponseDto<List<OrderResponseDto>>> GetAllOrders();
    }
}
