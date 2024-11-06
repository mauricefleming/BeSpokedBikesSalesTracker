using BespokedBikesSalesTracker.Services;
using BeSpokedBikesSalesTracker.Entities;
using BeSpokedBikesSalesTracker.Services;
using FluentValidation;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SalesTrackingContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<ISalesService, SalesService>();
builder.Services.AddSingleton<ISalespersonService, SalespersonService>();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<ICustomerService, CustomerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/sales/{startDate?}/{endDate?}",async (string? startDate, string? eendDate, ISalesService salesService) =>
{
    var sales = salesService.GetSales();
    return sales.Any() ? Results.Ok(sales) : Results.NotFound();
});


app.MapGet("/sales/{salespersonId}/{year}/{quarter}", async (int salespersonId, int year, int quarter, ISalesService salesService) =>
{
    var commission = salesService.GetQuarterlyCommission(salespersonId, year, quarter);
    return Results.Ok(commission);
});


app.MapPost("/product", async (Product product, IValidator<Product> validator, IProductService productService) =>
{
    var validationResult = await validator.ValidateAsync(product);
    if (!validationResult.IsValid)
    {
        return Results.ValidationProblem(validationResult.ToDictionary());
    }

    productService.AddProduct(product);
    return Results.Ok();
});

app.MapPost("/salesperson", async (Salesperson salesperson, IValidator<Salesperson> validator, ISalespersonService salespersonService) =>
{
    var validationResult = await validator.ValidateAsync(salesperson);
    if (!validationResult.IsValid)
    {
        return Results.ValidationProblem(validationResult.ToDictionary());
    }

    salespersonService.AddSalesperson(salesperson);
    return Results.Ok();
});

app.MapPut("/product", async (Product product, IValidator<Product> validator, IProductService productService) =>
{
    var validationResult = await validator.ValidateAsync(product);
    if (!validationResult.IsValid)
    {
        return Results.ValidationProblem(validationResult.ToDictionary());
    }

    productService.UpdateProduct(product);
    return Results.Ok();
});

app.MapPost("/sale", async (Sale sale, IValidator<Sale> validator, ISalesService salesService) =>
{
    var validationResult = await validator.ValidateAsync(sale);
    if (!validationResult.IsValid)
    {
        return Results.ValidationProblem(validationResult.ToDictionary());
    }

    salesService.CreateSale(sale);
    return Results.Ok();
});

app.MapPut("/salesperson", async (Salesperson salesperson, IValidator<Salesperson> validator, ISalespersonService SalespersonService) =>
{
    var validationResult = await validator.ValidateAsync(salesperson);
    if (!validationResult.IsValid)
    {
        return Results.ValidationProblem(validationResult.ToDictionary());
    }

    SalespersonService.UpdateSalesperson(salesperson);
    return Results.Ok();
});

app.MapGet("/salespersons", (ISalespersonService SalespersonService) =>
    TypedResults.Ok(SalespersonService.GetSalespersons()))
    .WithName("GetSalespersons")
    .WithOpenApi(x => new OpenApiOperation(x)
    {
        Summary = "Get list of salespersons",
        Description = "Returns information about all salespersons.",
        Tags = new List<OpenApiTag> { new() { Name = "BeSpoked Bikes salespersons" } }
    });

app.MapGet("/customers", (ICustomerService CustomerService) =>
    TypedResults.Ok(CustomerService.GetCustomers()))
    .WithName("GetCustomers")
    .WithOpenApi(x => new OpenApiOperation(x)
    {
        Summary = "Get list of customers",
        Description = "Returns information about all customers.",
        Tags = new List<OpenApiTag> { new() { Name = "BeSpoked Bikes customers" } }
    });

app.MapGet("/products", (IProductService ProductService) =>
    TypedResults.Ok(ProductService.GetProducts()))
    .WithName("GetProducts")
    .WithOpenApi(x => new OpenApiOperation(x)
    {
        Summary = "Get list of products",
        Description = "Returns information about all products.",
        Tags = new List<OpenApiTag> { new() { Name = "BeSpoked Bikes products" } }
    });

app.Run();


