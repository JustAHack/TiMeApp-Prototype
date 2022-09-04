using AutoMapper;
using TiMePrototype.Application.DTOs.Shift;
using TiMePrototype.Application.DTOs.User;
using TiMePrototype.Domain;

namespace TiMePrototype.Application.Profiles;

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<Shift, ShiftDto>().ReverseMap();
		CreateMap<Shift, CreateShiftDto>().ReverseMap();
		CreateMap<Shift, CreateShiftWithUserDto>().ReverseMap();
		CreateMap<Shift, UpdateShiftDto>().ReverseMap();
		CreateMap<Shift, ShiftDetailsDto>().ReverseMap();

		CreateMap<User, UserDto>().ReverseMap()
			.ForMember(dst => dst.Password, opt => opt.Ignore());
		CreateMap<User, LoginUserDto>().ReverseMap();
		CreateMap<User, RegisterUserDto>().ReverseMap();
	}
}
