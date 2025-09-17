using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.Product;

namespace ApiCallService.ApplicationContract.Interfaces.Internal.Product
{
    public interface IProductAppService
    {
        Task<BaseResponseDto<List<ProductDto>>> GetAllProductsAsync();
        Task<BaseResponseDto<ProductDto>> GetProductByIdAsync(int id);
        Task<BaseResponseDto<ProductDto>> CreateProductAsync(ProductDto productDto);
        Task<BaseResponseDto<ProductDto>> EditProductAsync(int id, ProductDto productDto);
        Task<BaseResponseDto<ProductDto>> DeleteProductAsync(int id);

    }
}
