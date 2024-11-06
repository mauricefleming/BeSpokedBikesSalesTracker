using BeSpokedBikesSalesTracker.Entities;

namespace BeSpokedBikesSalesTracker.Services
{
    public interface ISalespersonService
    {
        void AddSalesperson(Salesperson salesperson);
        void DeleteSalesperson(int id);
        Salesperson? GetSalespersonById(int id);
        IEnumerable<Salesperson> GetSalespersons();
        void UpdateSalesperson(Salesperson salesperson);
    }
}
