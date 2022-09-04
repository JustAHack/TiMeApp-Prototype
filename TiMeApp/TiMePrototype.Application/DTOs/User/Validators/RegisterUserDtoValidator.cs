using FluentValidation;
using TiMePrototype.Application.Contracts.Persistence;

namespace TiMePrototype.Application.DTOs.User.Validators;

public class RegisterUserDtoValidator : AbstractValidator<RegisterUserDto>
{
	private readonly IUserRepository _userRepository;

	public RegisterUserDtoValidator(IUserRepository userRepository)
	{
        _userRepository = userRepository;

        Include(new IUserDtoValidator());

		RuleFor(x => x.UserName)
			.MustAsync(async (username, token) =>
			{
				var userExists = await _userRepository.UserNameExists(username);
				return !userExists;
			}).WithMessage("The {PropertyName} '{PropertyValue}' is not available.");
	}
}
