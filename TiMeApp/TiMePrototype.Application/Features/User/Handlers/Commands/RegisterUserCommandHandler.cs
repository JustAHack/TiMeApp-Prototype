using AutoMapper;
using MediatR;
using TiMePrototype.Application.Contracts.Persistence;
using TiMePrototype.Application.DTOs.User.Validators;
using TiMePrototype.Application.Features.User.Requests.Commands;
using TiMePrototype.Application.Responses;

namespace TiMePrototype.Application.Features.User.Handlers.Commands;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, BaseCommandResponse>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new RegisterUserDtoValidator(_userRepository);
        var validationResult = await validator.ValidateAsync(request.RegisterUserDto);

        if (validationResult.IsValid == false)
        {
            response.Success = false;
            response.Message = "Registration failed.";
            response.ValidationErrors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

            return response;
        }

        var user = _mapper.Map<Domain.User>(request.RegisterUserDto);
        user = await _userRepository.AddAsync(user);

        response.Success = true;
        response.Message = "Registration successful";
        response.Id = user.Id;

        return response;
    }
}
