using BeSpokedBikesSalesTracker.Entities;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BeSpokedBikesSalesTracker.Validators
{
    public class SalespersonValidator : AbstractValidator<Salesperson>
    {
        public SalespersonValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Address).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Phone).NotEmpty()
                                .NotNull().WithMessage("Phone Number is required.")
                                .MinimumLength(10).WithMessage("PhoneNumber must not be less than 10 characters.")
                                .MaximumLength(20).WithMessage("PhoneNumber must not exceed 50 characters.")
                                .Matches(new Regex(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}")).WithMessage("PhoneNumber not valid");
            RuleFor(x => x.StartDate).NotEmpty();            
            RuleFor(x => x.Manager).NotEmpty().MaximumLength(50);
        }
    }
}
