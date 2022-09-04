using AutoMapper;
using MediatR;
using TiMePrototype.Application.Contracts.Persistence;
using TiMePrototype.Application.DTOs.Shift;
using TiMePrototype.Application.Features.Shift.Requests.Queries;

namespace TiMePrototype.Application.Features.Shift.Handlers.Queries
{
    public class GetUsersShiftsRequestHandler : IRequestHandler<GetUsersShiftsRequest, List<ShiftDto>>
    {
        private readonly IShiftRepository _shiftRepository;
        private readonly IMapper _mapper;

        public GetUsersShiftsRequestHandler(IShiftRepository shiftRepository, IMapper mapper)
        {
            _shiftRepository = shiftRepository;
            _mapper = mapper;
        }

        public async Task<List<ShiftDto>> Handle(GetUsersShiftsRequest request, CancellationToken cancellationToken)
        {
            var shifts = await _shiftRepository.GetUsersShifts(request.UserId);
            return _mapper.Map<List<ShiftDto>>(shifts);
        }
    }
}
