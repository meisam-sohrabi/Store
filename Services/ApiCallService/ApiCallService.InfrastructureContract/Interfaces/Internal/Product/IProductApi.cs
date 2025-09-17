using First.ApplicationContract.DTO.Base;
using First.ApplicationContract.DTO.Internal.Product;

namespace First.InfrastructureContract.Interfaces.Internal.Product
{
    public interface IProductApi
    {
        Task<BaseResponseDto<List<ProductDto>>> GetAllProductsAsync();
        Task<BaseResponseDto<ProductDto>> GetProductByIdAsync(int id);
        Task<BaseResponseDto<ProductDto>> CreateProductAsync(ProductDto productDto);
        Task<BaseResponseDto<ProductDto>> EditProductAsync(int id, ProductDto productDto);
        Task<BaseResponseDto<ProductDto>> DeleteProductAsync(int id);

    }
}
