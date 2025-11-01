using InventoryService.ApplicationContract.DTO.Base;
using InventoryService.ApplicationContract.DTO.ProductInventory;

namespace InventoryService.ApplicationContract.Interfaces.ProductInventory
{
    public interface IProductInventoryAppService
    {
        Task<BaseResponseDto<ProductInventoryResponseDto>> CreateProductInventory(ProductInventoryRequestDto productInventoryRequestDto);
    }
}
