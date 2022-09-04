using FluentValidation;

namespace TiMePrototype.Application.DTOs.Shift.Validators;

public class IShiftDtoValidator : AbstractValidator<IShiftDto>
{
    public IShiftDtoValidator()
    {
        RuleFor(x => x.StartTime)
        .NotEmpty().WithMessage("{PropertyName} is required.")
        .NotNull()
        .LessThan(x => x.EndTime).WithMessage("{PropertyName} must be before {ComparisonValue}");

        RuleFor(x => x.EndTime)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .GreaterThan(x => x.StartTime).WithMessage("{PropertyName} must be after {ComparisonValue}");
    }
}
