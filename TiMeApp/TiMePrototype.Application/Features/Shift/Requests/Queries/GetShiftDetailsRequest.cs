using MediatR;
using TiMePrototype.Application.DTOs.Shift;

namespace TiMePrototype.Application.Features.Shift.Requests.Queries;

public class GetShiftDetailsRequest : IRequest<ShiftDetailsDto>
{
    public int Id { get; set; }
}
