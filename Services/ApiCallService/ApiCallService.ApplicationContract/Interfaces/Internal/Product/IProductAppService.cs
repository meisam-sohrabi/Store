using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.Product;

namespace ApiCallService.ApplicationContract.Interfaces.Internal.Product
{
    public interface IProductAppService
    {
        Task<BaseResponseDto<List<ProductResponseDto>>> GetAllProductsAsync();
        Task<BaseResponseDto<ProductResponseDto>> GetProductByIdAsync(int id);
        Task<BaseResponseDto<ProductResponseDto>> CreateProductAsync(ProductRequestDto productDto);
        Task<BaseResponseDto<ProductResponseDto>> EditProductAsync(int id, ProductRequestDto productDto);
        Task<BaseResponseDto<ProductResponseDto>> DeleteProductAsync(int id);

    }
}
