using Dapper;
using Microsoft.EntityFrameworkCore;
using ShopService.ApplicationContract.DTO.Product;
using ShopService.Domain.Entities;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;
using ShopService.InfrastructureContract.Interfaces.Query.Product;
using System.Data;
namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Query.Product
{
    public class ProductQueryRepository : IProductQueryRespository
    {
        private readonly ApplicationDbContext _context;

        public ProductQueryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductWithInventoryDto>> GetProductsByDateAndTextAsync(string? textSearch, DateTime? startDate, DateTime? endDate)
        {
            var procedureName = "GetProductByDateAndTextSearch";
            var parameters = new { textSearch, startDate, endDate };
            using (var connection = _context.Database.GetDbConnection())
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                var affectedRows = await connection.QueryAsync<ProductWithInventoryDto>(procedureName, parameters, commandType: CommandType.StoredProcedure);
                return affectedRows.ToList();
            }

        }


        #region Get
        public IQueryable<ProductEntity> GetQueryable()
        {
            return _context.Products.AsQueryable();
        }
        #endregion

    }
}
