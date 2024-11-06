using BeSpokedBikesSalesTracker.Entities;
using BeSpokedBikesSalesTracker.Services;
using Microsoft.EntityFrameworkCore;
namespace BespokedBikesSalesTracker.Services
{
    public class SalespersonService : ISalespersonService
    {
        private readonly SalesTrackingContext _context;

        public SalespersonService(SalesTrackingContext context)
        {
            _context = context;
        }

        public IEnumerable<Salesperson> GetSalespersons()
        {
            return _context.Salespersons.ToList();
        }

        public Salesperson? GetSalespersonById(int id)
        {
            return _context.Salespersons.Find(id);
        }

        public void AddSalesperson(Salesperson salesperson)
        {
           
                _context.Salespersons.Add(salesperson);
                _context.SaveChanges();
        }

        public void UpdateSalesperson(Salesperson salesperson)
        {
            _context.Salespersons.Update(salesperson);
            _context.SaveChanges();
        }

        public void DeleteSalesperson(int id)
        {
            var salesperson = _context.Salespersons.Find(id);
            if (salesperson != null)
            {
                _context.Salespersons.Remove(salesperson);
                _context.SaveChanges();
            }
        }

        /* public bool SalespersonExists(Salesperson salesperson)
         {
              return _context.Salespersons.Any(e => 
         e.FirstName == salesperson.FirstName &&
         e.LastName == salesperson.LastName &&
         e.Address == salesperson.Address &&
         e.Phone == salesperson.Phone &&
         e.StartDate == salesperson.StartDate &&
         e.Manager == salesperson.Manager);
         }*/
    }

}
