using BeSpokedBikesSalesTracker.Entities;
using FluentValidation;

namespace BeSpokedBikesSalesTracker.Validators
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.SalespersonId).NotEmpty();
            RuleFor(x => x.SalesDate).NotEmpty();           
        }
    }
}
