using BeSpokedBikesSalesTracker.Entities;
using BeSpokedBikesSalesTracker.Services;
using Microsoft.EntityFrameworkCore;
namespace BeSpokedBikesSalesTracker.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly SalesTrackingContext _context;

        public CustomerService(SalesTrackingContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

    }
}
