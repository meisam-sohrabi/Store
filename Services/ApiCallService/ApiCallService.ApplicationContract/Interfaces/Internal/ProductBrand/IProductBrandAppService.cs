using ApiCallService.ApplicationContract.DTO.Base;
using ApiCallService.ApplicationContract.DTO.Internal.ProductBrand;

namespace ApiCallService.ApplicationContract.Interfaces.Internal.ProductBrand
{
    public interface IProductBrandAppService
    {
        Task<BaseResponseDto<List<ProductBrandDto>>> GetAllProductBrandsAsync();
        Task<BaseResponseDto<ProductBrandDto>> GetProductBrandByIdAsync(int id);
        Task<BaseResponseDto<ProductBrandDto>> CreateProductBrandAsync(ProductBrandDto ProductBrandDto);
        Task<BaseResponseDto<ProductBrandDto>> EditProductBrandAsync(int id, ProductBrandDto ProductBrandDto);
        Task<BaseResponseDto<ProductBrandDto>> DeleteProductBrandAsync(int id);
    }
}
