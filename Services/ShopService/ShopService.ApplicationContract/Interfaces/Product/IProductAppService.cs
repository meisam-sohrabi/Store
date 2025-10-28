using ShopService.ApplicationContract.DTO.Base;
using ShopService.ApplicationContract.DTO.Product;
using ShopService.ApplicationContract.DTO.Search;
using ShopService.ApplicationContract.DTO.Transaction;

namespace ShopService.ApplicationContract.Interfaces.Product
{
    public interface IProductAppService
    {
        Task<BaseResponseDto<ProductTransactionDto>> ProductTransaction(ProductTransactionDto productTransactionDto,int categoryId,int productBrandId);
        Task<BaseResponseDto<ProductResponseDto>> EditProduct(int id, ProductRequestDto productDto);
        Task<BaseResponseDto<ProductResponseDto>> EditArabicToPersianSP(ProductArabicToPersianDto productArabicToPersianDto);
        Task<BaseResponseDto<ProductResponseDto>> DeleteProduct(int id);
        Task<BaseResponseDto<List<ProductResponseDto>>> GetAllProduct();
        Task<BaseResponseDto<ProductResponseDto>> GetProduct(int id);
        Task<BaseResponseDto<List<SearchResponseDto>>> AdvanceSearchProduct(SearchRequestDto searchRequstDto);
        Task<BaseResponseDto<List<ProductWithInventoryDto>>> GetProductWithInventory(string? search,DateTime? start,DateTime? end);
        Task<List<ProductResponseDto>> GetProductsReport();

    }
}
