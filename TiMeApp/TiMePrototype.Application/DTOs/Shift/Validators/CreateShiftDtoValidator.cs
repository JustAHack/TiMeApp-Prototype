using FluentValidation;

namespace TiMePrototype.Application.DTOs.Shift.Validators;

public class CreateShiftDtoValidator : AbstractValidator<CreateShiftWithUserDto>
{
	public CreateShiftDtoValidator()
	{
        Include(new IShiftDtoValidator());
    }
}
