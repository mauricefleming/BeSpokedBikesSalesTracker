using BeSpokedBikesSalesTracker.Entities;
using FluentValidation;

namespace BeSpokedBikesSalesTracker.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Manufacturer).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Style).NotEmpty().MaximumLength(50);
            RuleFor(x => x.PurchasePrice).NotEmpty();
            RuleFor(x => x.SalePrice).NotEmpty();
        }
    }
}
