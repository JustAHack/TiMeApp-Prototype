using AutoMapper;
using MediatR;
using TiMePrototype.Application.Contracts.Persistence;
using TiMePrototype.Application.DTOs.Shift;
using TiMePrototype.Application.Features.Shift.Requests.Queries;

namespace TiMePrototype.Application.Features.Shift.Handlers.Queries;

public class GetShiftDetailsRequestHandler : IRequestHandler<GetShiftDetailsRequest, ShiftDetailsDto>
{
    private readonly IShiftRepository _shiftRepository;
    private readonly IMapper _mapper;

    public GetShiftDetailsRequestHandler(IShiftRepository shiftRepository, IMapper mapper)
    {
        _shiftRepository = shiftRepository;
        _mapper = mapper;
    }

    public async Task<ShiftDetailsDto> Handle(GetShiftDetailsRequest request, CancellationToken cancellationToken)
    {
        var shift = await _shiftRepository.GetAsync(request.Id);

        return _mapper.Map<ShiftDetailsDto>(shift);
    }
}
