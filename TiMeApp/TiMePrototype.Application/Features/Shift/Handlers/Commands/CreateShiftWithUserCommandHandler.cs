using AutoMapper;
using FluentValidation;
using MediatR;
using TiMePrototype.Application.Contracts.Persistence;
using TiMePrototype.Application.DTOs.Shift.Validators;
using TiMePrototype.Application.Features.Shift.Requests.Commands;
using TiMePrototype.Application.Responses;

namespace TiMePrototype.Application.Features.Shift.Handlers.Commands;

public class CreateShiftWithUserCommandHandler : IRequestHandler<CreateShiftWithUserCommand, BaseCommandResponse>
{
    private readonly IShiftRepository _shiftRepository;
    private readonly IMapper _mapper;

    public CreateShiftWithUserCommandHandler(IShiftRepository shiftRepository, IMapper mapper)
    {
        _shiftRepository = shiftRepository;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(CreateShiftWithUserCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateShiftDtoValidator();
        var validationResult = await validator.ValidateAsync(request.ShiftDto);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Failed to save the shift.";
            response.ValidationErrors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

            return response;
        }

        var shift = _mapper.Map<Domain.Shift>(request.ShiftDto);
        shift = await _shiftRepository.AddAsync(shift);

        response.Success = true;
        response.Message = "Shift successfully saved.";
        response.Id = shift.Id;

        return response;
    }
}
