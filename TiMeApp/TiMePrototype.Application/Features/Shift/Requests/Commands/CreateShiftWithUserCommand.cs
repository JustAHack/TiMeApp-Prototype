using MediatR;
using TiMePrototype.Application.DTOs.Shift;
using TiMePrototype.Application.Responses;

namespace TiMePrototype.Application.Features.Shift.Requests.Commands;

public class CreateShiftWithUserCommand : IRequest<BaseCommandResponse>
{
    public CreateShiftWithUserDto ShiftDto { get; set; }
}
