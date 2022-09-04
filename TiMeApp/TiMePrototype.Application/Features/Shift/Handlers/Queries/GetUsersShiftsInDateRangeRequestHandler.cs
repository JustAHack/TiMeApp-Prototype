using AutoMapper;
using MediatR;
using TiMePrototype.Application.Contracts.Persistence;
using TiMePrototype.Application.DTOs.Shift;
using TiMePrototype.Application.Features.Shift.Requests.Queries;

namespace TiMePrototype.Application.Features.Shift.Handlers.Queries;

public class GetUsersShiftsInDateRangeRequestHandler : IRequestHandler<GetUsersShiftsInDateRangeRequest, List<ShiftDto>>
{
    private readonly IShiftRepository _shiftRepository;
    private readonly IMapper _mapper;

    public GetUsersShiftsInDateRangeRequestHandler(IShiftRepository shiftRepository, IMapper mapper)
    {
        _shiftRepository = shiftRepository;
        _mapper = mapper;
    }

    public async Task<List<ShiftDto>> Handle(GetUsersShiftsInDateRangeRequest request, CancellationToken cancellationToken)
    {
        var endDate = request.EndDate.AddDays(1).Subtract(TimeSpan.FromSeconds(1));
        var shifts = await _shiftRepository.GetUsersShiftsBetweenDates(request.UserId, request.StartDate, endDate);
        return _mapper.Map<List<ShiftDto>>(shifts);
    }
}
