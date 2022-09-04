using MediatR;
using TiMePrototype.Application.DTOs.Shift;

namespace TiMePrototype.Application.Features.Shift.Requests.Commands
{
    public class UpdateShiftCommand : IRequest<Unit>
    {
        public ShiftDetailsDto ShiftDto { get; set; }
    }
}
