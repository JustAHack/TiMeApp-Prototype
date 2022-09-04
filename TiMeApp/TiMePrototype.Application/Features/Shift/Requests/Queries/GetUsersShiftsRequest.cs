using MediatR;
using TiMePrototype.Application.DTOs.Shift;

namespace TiMePrototype.Application.Features.Shift.Requests.Queries
{
    public class GetUsersShiftsRequest : IRequest<List<ShiftDto>>
    {
        public int UserId { get; set; }
    }
}
