
using BeSpokedBikesSalesTracker.Entities;

public static class DataSeeder
{
    public static void SeedData(SalesTrackingContext context)
    {
        if (!context.Products.Any())
        {
            context.Products.AddRange(
            new Product { Name = "Product1", Manufacturer = "Manufacturer1", Style = "Style1", PurchasePrice = 10, SalePrice = 20, QtyOnHand = 100, CommissionPercentage = (double)0.1m },
            new Product { Name = "Product2", Manufacturer = "Manufacturer2", Style = "Style2", PurchasePrice = 15, SalePrice = 30, QtyOnHand = 200, CommissionPercentage = (double)0.15m },
            new Product { Name = "Product3", Manufacturer = "Manufacturer3", Style = "Style3", PurchasePrice = 20, SalePrice = 40, QtyOnHand = 150, CommissionPercentage = (double)0.2m }
           );
        }

        if (!context.Salespersons.Any())
        {
            context.Salespersons.AddRange(
                new Salesperson { FirstName = "John", LastName = "Doe", Address = "123 Main St", Phone = "555-1234", StartDate = DateTime.Now, TerminationDate=null, Manager = "Manager1" },
                new Salesperson { FirstName = "Alice", LastName = "Johnson", Address = "789 Oak St", Phone = "555-9876", StartDate = DateTime.Now, Manager = "Manager2"}
            );
        }

        if (!context.Customers.Any())
        {
            context.Customers.AddRange(
                new Customer { FirstName = "Jane", LastName = "Smith", Address = "456 Elm St", Phone = "555-5678", StartDate = DateTime.Now },
                new Customer { FirstName = "Bob", LastName = "Brown", Address = "321 Pine St", Phone = "555-4321", StartDate = DateTime.Now }
            );
        }

        if (!context.Sales.Any())
        {
            context.Sales.AddRange(
                new Sale { ProductId = 1, SalespersonId = 1, CustomerId = 1, SalesDate = DateTime.Now},
                new Sale { ProductId = 2, SalespersonId = 2, CustomerId = 2, SalesDate = DateTime.Now}
            );
        }

        if (!context.Discounts.Any())
        {
            context.Discounts.AddRange(
                new Discount { ProductId = 1, BeginDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1), DiscountPercentage = (double)0.1m },
                new Discount { ProductId = 2, BeginDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1), DiscountPercentage = (double)0.15m }
            );
        }

        context.SaveChanges();
    }
}