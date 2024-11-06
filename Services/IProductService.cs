using BeSpokedBikesSalesTracker.Entities;

namespace BeSpokedBikesSalesTracker.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        void UpdateProduct(Product product);
        void AddProduct(Product product);
    }
}