using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Product;

namespace ShopService.ApplicationContract.Interfaces.Product
{
    public interface IProductAppService
    {
        Task<BaseResponseDto<ProductDto>> CreateProduct(ProductDto productDto);
        Task<BaseResponseDto<ProductDto>> EditProduct(int id, ProductDto productDto);
        Task<BaseResponseDto<ProductDto>> DeleteProduct(int id);
        Task<BaseResponseDto<ProductDto>> GetProduct(int id);
    }
}
