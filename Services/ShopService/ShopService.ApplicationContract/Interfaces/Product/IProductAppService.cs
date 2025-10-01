using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Product;
using ShopService.ApplicationContract.DTO.Search;

namespace ShopService.ApplicationContract.Interfaces.Product
{
    public interface IProductAppService
    {
        Task<BaseResponseDto<ProductResponseDto>> CreateProduct(ProductRequestDto productDto);
        Task<BaseResponseDto<ProductResponseDto>> EditProduct(int id, ProductRequestDto productDto);
        Task<BaseResponseDto<ProductResponseDto>> DeleteProduct(int id);
        Task<BaseResponseDto<List<ProductResponseDto>>> GetAllProduct();
        Task<BaseResponseDto<ProductResponseDto>> GetProduct(int id);
        Task<BaseResponseDto<List<SearchResponseDto>>> AdvanceSearchProduct(SearchRequestDto searchRequstDto);

    }
}
