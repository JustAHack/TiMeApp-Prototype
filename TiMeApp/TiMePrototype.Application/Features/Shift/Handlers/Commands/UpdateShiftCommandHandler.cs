using AutoMapper;
using MediatR;
using TiMePrototype.Application.Contracts.Persistence;
using TiMePrototype.Application.DTOs.Shift.Validators;
using TiMePrototype.Application.Exceptions;
using TiMePrototype.Application.Features.Shift.Requests.Commands;

namespace TiMePrototype.Application.Features.Shift.Handlers.Commands
{
    public class UpdateShiftCommandHandler : IRequestHandler<UpdateShiftCommand, Unit>
    {
        private readonly IShiftRepository _shiftRepository;
        private readonly IMapper _mapper;

        public UpdateShiftCommandHandler(IShiftRepository shiftRepository, IMapper mapper)
        {
            _shiftRepository = shiftRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateShiftCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateShiftDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ShiftDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var shift = await _shiftRepository.GetAsync(request.ShiftDto.Id);

            if (request.ShiftDto != null)
            {
                _mapper.Map(request.ShiftDto, shift);
                await _shiftRepository.UpdateAsync(shift);
            }

            return Unit.Value;
        }
    }
}
