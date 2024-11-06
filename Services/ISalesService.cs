using BeSpokedBikesSalesTracker.Entities;

namespace BespokedBikesSalesTracker.Services
{
    public interface ISalesService
    {
        void CreateSale(Sale sale);
        decimal GetQuarterlyCommission(int salespersonId, int year, int quarter);
        IEnumerable<Sale> GetSales(DateTime? startDate = null, DateTime? endDate = null);
    }
}
