using FluentValidation;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandValidator : AbstractValidator<EditCarWorkshopCommand>
    {
        public EditCarWorkshopCommandValidator()
        {
            RuleFor(c => c.Description)
                .NotEmpty();
            RuleFor(c => c.PhoneNumber)
                .MinimumLength(8)
                .MaximumLength(12);
            RuleFor(c => c.EmailAddress)
                .EmailAddress()
                .NotEmpty();
        }
    }
}