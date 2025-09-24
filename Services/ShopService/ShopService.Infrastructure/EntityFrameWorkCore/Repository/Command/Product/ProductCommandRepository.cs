using ShopService.Domain.Entities;
using ShopService.InfrastructureContract.Interfaces.Command.Product;
using ShopService.Infrastructure.EntityFrameWorkCore.AppDbContext;

namespace ShopService.Infrastructure.EntityFrameWorkCore.Repository.Command.Product
{
    public class ProductCommandRepository : IProductCommandRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductCommandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Add
        public void Add(ProductEntity product)
        {
            _context.Products.Add(product);
        }
        #endregion

        #region Delete
        public void Delete(ProductEntity product)
        {
            _context.Remove(product);
        }
        #endregion

        #region Edit
        public void Edit(ProductEntity product)
        {
            var entry = _context.Entry(product);
            var key = _context.Model.FindEntityType(typeof(ProductEntity))?.FindPrimaryKey();
            if (key != null)
            {
                foreach (var property in key.Properties)
                {
                    entry.Property(property.Name).IsModified = false;
                }
            }
        }
        #endregion

    }
}
