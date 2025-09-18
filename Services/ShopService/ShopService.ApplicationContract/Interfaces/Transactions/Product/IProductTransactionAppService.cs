using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Transaction;

namespace ShopService.ApplicationContract.Interfaces.Transactions.Product
{
    public interface IProductTransactionAppService
    {
        Task<BaseResponseDto<ProductTransactionDto>> ProductTransaction(ProductTransactionDto productTransactionDto);
    }
}
