using FluentValidation;
using TripPortal.Models.Entities;
using TripPortal.Models.ViewModel;

namespace TripPortal.Validators
{
    public class AddReservationViewModelValidator : AbstractValidator<AddReservationViewModel>
    {
        public AddReservationViewModelValidator()
        {
            RuleFor(r => r.TripID)
              .NotEmpty().WithMessage("Trip is required.");

            RuleFor(r => r.StudentID)
              .NotEmpty().WithMessage("Student is required.");

            RuleFor(r => r.ReservationDate)
              .LessThanOrEqualTo(DateTime.Now).WithMessage("Reservation date cannot be in the future.");

            RuleFor(r => r.PaymentDate)
              .GreaterThanOrEqualTo(r => r.ReservationDate).WithMessage("Payment date must be after or on reservation date.");

            RuleFor(r => r.PriceForAll)
              .NotEmpty().WithMessage("Price is required.")
              .GreaterThan(0).WithMessage("Price must be a positive value.");
        }
    }
}
