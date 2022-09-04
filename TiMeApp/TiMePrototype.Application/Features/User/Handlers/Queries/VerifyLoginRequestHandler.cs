using AutoMapper;
using MediatR;
using SimpleHashing;
using TiMePrototype.Application.Contracts.Persistence;
using TiMePrototype.Application.DTOs.User;
using TiMePrototype.Application.Features.User.Requests.Queries;

namespace TiMePrototype.Application.Features.User.Handlers.Queries
{
    public class VerifyLoginRequestHandler : IRequestHandler<VerifyLoginRequest, UserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public VerifyLoginRequestHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(VerifyLoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.VerifyUser(request.user.UserName);
            if (user == null)
                return null;

            if (user != null && PBKDF2.Verify(user.Password, request.user.Password))
            {
                var userDto = _mapper.Map<UserDto>(user);
                return userDto;
            }

            return null;
        }
    }
}
