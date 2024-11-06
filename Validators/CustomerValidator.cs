using BeSpokedBikesSalesTracker.Entities;
using FluentValidation;

namespace BeSpokedBikesSalesTracker.Validators
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty();
        }
    }
}
