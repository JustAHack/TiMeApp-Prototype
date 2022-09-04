using System.ComponentModel.DataAnnotations;
using TiMePrototype.Application.DTOs.Common;

namespace TiMePrototype.Application.DTOs.User;

public class RegisterUserDto : BaseDto, IUserDto
{
    [Display(Name = "User name")]
    [Required]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}
