using MediatR;
using TiMePrototype.Application.DTOs.User;

namespace TiMePrototype.Application.Features.User.Requests.Queries;

public class VerifyLoginRequest : IRequest<UserDto>
{
    public LoginUserDto user { get; set; }
}
