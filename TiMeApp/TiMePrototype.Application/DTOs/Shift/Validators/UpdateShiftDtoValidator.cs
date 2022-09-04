using FluentValidation;
using TiMePrototype.Application.Contracts.Persistence;

namespace TiMePrototype.Application.DTOs.Shift.Validators
{
    public class UpdateShiftDtoValidator : AbstractValidator<ShiftDetailsDto>
    {
        public UpdateShiftDtoValidator()
        {
            Include(new IShiftDtoValidator());
        }
    }
}
