using FluentValidation;
using TripPortal.Models;
using TripPortal.Models.Entities;

namespace TripPortal.Validators
{
    public class AddTripViewModelValidator : AbstractValidator<AddTripViewModel>
    {
        public AddTripViewModelValidator()
        {
            RuleFor(t => t.Country)
              .NotEmpty().WithMessage("Country is required.");

            RuleFor(t => t.City)
              .NotEmpty().WithMessage("City is required.");

            RuleFor(t => t.Price)
              .NotEmpty().WithMessage("Price is required.")
              .InclusiveBetween(0, decimal.MaxValue).WithMessage("Price must be a positive value.");

            RuleFor(t => t.StartDate)
              .LessThan(t => t.EndDate).WithMessage("Start date must be before end date.");
        }
    }
}
