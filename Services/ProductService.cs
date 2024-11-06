using BeSpokedBikesSalesTracker.Entities;
using BeSpokedBikesSalesTracker.Services;
using Microsoft.EntityFrameworkCore;
namespace BeSpokedBikesSalesTracker.Services
{
    public class ProductService : IProductService
    {
        private readonly SalesTrackingContext _context;
        public ProductService(SalesTrackingContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
    }
}
