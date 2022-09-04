using MediatR;
using TiMePrototype.Application.DTOs.User;
using TiMePrototype.Application.Responses;

namespace TiMePrototype.Application.Features.User.Requests.Commands;

public class RegisterUserCommand : IRequest<BaseCommandResponse>
{
    public RegisterUserDto RegisterUserDto { get; set; }
}
