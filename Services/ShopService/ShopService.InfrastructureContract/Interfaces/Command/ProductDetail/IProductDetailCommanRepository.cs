using ShopService.Domain.Entities;

namespace ShopService.InfrastructureContract.Interfaces.Command.ProductDetail
{
    public interface IProductDetailCommanRepository
    {
        void Add(ProductDetailEntity productDetail);
        void Edit(ProductDetailEntity productDetail);
        void Delete(ProductDetailEntity productDetail);
    }
}
