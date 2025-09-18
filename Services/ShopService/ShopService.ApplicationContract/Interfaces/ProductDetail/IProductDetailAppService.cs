using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.ProductDetail;

namespace ShopService.ApplicationContract.Interfaces.ProductDetail
{
    public interface IProductDetailAppService
    {
        Task<BaseResponseDto<ProductDetailDto>> CreateProductDetail(ProductDetailDto ProductDetailDto);

        Task<BaseResponseDto<ProductDetailDto>> EditProductDetail(int id, ProductDetailDto ProductDetailDto);
        Task<BaseResponseDto<List<ProductDetailDto>>> GetAllProductDetails();
        Task<BaseResponseDto<ProductDetailDto>> GetProductDetail(int id);
        Task<BaseResponseDto<ProductDetailDto>> DeleteProductDetail(int id);
    }
}
