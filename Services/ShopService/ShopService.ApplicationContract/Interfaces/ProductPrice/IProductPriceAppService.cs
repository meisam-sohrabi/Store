using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.ProductPrice;

namespace ShopService.ApplicationContract.Interfaces.ProductPrice
{
    public interface IProductPriceAppService
    {
        Task<BaseResponseDto<ProductPriceResponseDto>> EditProductPrice(int id, ProductPriceRequestDto productPriceRequestDto);
        Task<BaseResponseDto<ProductPriceResponseDto>> DeleteProductPrice(int id);
        Task<BaseResponseDto<ProductPriceResponseDto>> GetProductPrice(int id);
        Task<BaseResponseDto<List<ProductPriceResponseDto>>> GetAllProductPrice();
    }
}
