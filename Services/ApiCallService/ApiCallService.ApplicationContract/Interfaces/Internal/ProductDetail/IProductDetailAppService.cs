using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.ProductDetail;

namespace ApiCallService.ApplicationContract.Interfaces.Internal.ProductDetail
{
    public interface IProductDetailAppService
    {
        Task<BaseResponseDto<List<ProductDetailDto>>> GetAllProductDetailsAsync();
        Task<BaseResponseDto<ProductDetailDto>> GetProductDetailByIdAsync(int id);
        Task<BaseResponseDto<ProductDetailDto>> CreateProductDetailAsync(ProductDetailDto productDetailDto);
        Task<BaseResponseDto<ProductDetailDto>> EditProductDetailAsync(int id, ProductDetailDto productDetailDto);
        Task<BaseResponseDto<ProductDetailDto>> DeleteProductDetailAsync(int id);
    }
}
