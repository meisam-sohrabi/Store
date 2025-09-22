using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.ProductDetail;

namespace ApiCallService.ApplicationContract.Interfaces.Internal.ProductDetail
{
    public interface IProductDetailAppService
    {
        Task<BaseResponseDto<List<ProductDetailResponseDto>>> GetAllProductDetailsAsync();
        Task<BaseResponseDto<ProductDetailResponseDto>> GetProductDetailByIdAsync(int id);
        Task<BaseResponseDto<ProductDetailResponseDto>> CreateProductDetailAsync(ProductDetailRequestDto productDetailDto);
        Task<BaseResponseDto<ProductDetailResponseDto>> EditProductDetailAsync(int id, ProductDetailRequestDto productDetailDto);
        Task<BaseResponseDto<ProductDetailResponseDto>> DeleteProductDetailAsync(int id);
    }
}
