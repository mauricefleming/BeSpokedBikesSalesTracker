using BeSpokedBikesSalesTracker.Entities;

namespace BeSpokedBikesSalesTracker.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetCustomers();
    }
}