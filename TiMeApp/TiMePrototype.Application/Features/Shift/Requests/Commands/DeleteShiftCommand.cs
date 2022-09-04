using MediatR;

namespace TiMePrototype.Application.Features.Shift.Requests.Commands;

public class DeleteShiftCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
