
using Microsoft.EntityFrameworkCore;
using BeSpokedBikesSalesTracker.Entities;
namespace BespokedBikesSalesTracker.Services { 
public class SalesService : ISalesService
{
    private readonly SalesTrackingContext _context;

    public SalesService(SalesTrackingContext context)
    {
        _context = context;
    }

        public IEnumerable<Sale> GetSales(DateTime? startDate = null, DateTime? endDate = null)
        {
            return _context.Sales
                .Include(s => s.Product)
                .Include(s => s.Salesperson)
                .Include(s => s.Customer)
                .Where(s => (!startDate.HasValue || s.SalesDate >= startDate) && (!endDate.HasValue || s.SalesDate <= endDate))
                .ToList();
        }

        public void CreateSale(Sale sale)
    {
        _context.Sales.Add(sale);
        _context.SaveChanges();
    }

        public decimal GetQuarterlyCommission(int salespersonId, int year, int quarter)
        {
            var startDate = new DateTime(year, (quarter - 1) * 3 + 1, 1);
            var endDate = startDate.AddMonths(3).AddDays(-1);

            return _context.Sales
                .Include(s => s.Product) // Ensure Product is included
                .Where(s => s.SalespersonId == salespersonId &&
                            s.SalesDate >= startDate &&
                            s.SalesDate <= endDate)
                .Sum(s => s.Product.SalePrice * (decimal)s.Product.CommissionPercentage / 100);
        }
    }
}
