using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.Transaction;

namespace ApiCallService.ApplicationContract.Interfaces.Internal.CategoryWithProduct
{
    public interface IProductTransactionAppService
    {
        Task<BaseResponseDto<ProductTransactionDto>> ProductTransaction(ProductTransactionDto productTransactionDto);
    }
}
