using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.ProductDetail;

namespace ShopService.ApplicationContract.Interfaces.ProductDetail
{
    public interface IProductDetailAppService
    {
        Task<BaseResponseDto<ProductDetailResponseDto>> CreateProductDetail(ProductDetailRequestDto ProductDetailDto);

        Task<BaseResponseDto<ProductDetailResponseDto>> EditProductDetail(int id, ProductDetailRequestDto ProductDetailDto);
        Task<BaseResponseDto<List<ProductDetailResponseDto>>> GetAllProductDetails();
        Task<BaseResponseDto<ProductDetailResponseDto>> GetProductDetail(int id);
        Task<BaseResponseDto<ProductDetailResponseDto>> DeleteProductDetail(int id);
    }
}
