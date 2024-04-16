using FluentValidation;
using TripPortal.Models.Entities;
using TripPortal.Models.ViewModel;

namespace TripPortal.Validators
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(s => s.Name)
              .NotEmpty().WithMessage("Name is required.");

            RuleFor(s => s.Surname)
              .NotEmpty().WithMessage("Surname is required.");

            RuleFor(s => s.Email)
              .NotEmpty().WithMessage("Email is required.")
              .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(s => s.Phone)
              .NotEmpty().WithMessage("Phone number is required.")
              .MinimumLength(9).MaximumLength(15)
              .Matches(@"^\d+$").WithMessage("Phone number must contain only digits.");

            RuleFor(s => s.PESEL)
              .NotEmpty().WithMessage("PESEL is required.")
              .Length(11).WithMessage("PESEL must be 11 characters long.");

            RuleFor(s => s.BirthDate)
              .LessThan(DateTime.Now).WithMessage("Birth date cannot be in the future.");
        }
    }
}
