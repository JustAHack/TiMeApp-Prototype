using FluentValidation;

namespace TiMePrototype.Application.DTOs.User.Validators;

public class IUserDtoValidator : AbstractValidator<IUserDto>
{
	public IUserDtoValidator()
	{
		RuleFor(x => x.UserName)
			.NotEmpty().WithMessage("{PropertyName} is required.")
			.NotNull()
			.MinimumLength(3).WithMessage("{PropertyName} must be greater than {MinLength} characters.")
			.MaximumLength(20).WithMessage("{PropertyName} must not be greater than {MaxLength} characters.");

    }
}
