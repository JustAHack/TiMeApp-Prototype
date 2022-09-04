using TiMePrototype.Application.DTOs.Common;

namespace TiMePrototype.Application.DTOs.User
{
    public class LoginUserDto : BaseDto, IUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
