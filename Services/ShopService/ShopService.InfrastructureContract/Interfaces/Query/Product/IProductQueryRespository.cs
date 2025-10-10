using ShopService.ApplicationContract.DTO.Product;
using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Query.Product
{
    public interface IProductQueryRespository
    {
        IQueryable<ProductEntity> GetQueryable();
        Task<List<ProductWithInventoryDto>> GetProductsByDateAndTextAsync(string? textSearch, DateTime? startDate, DateTime? endDate);
    }
}
