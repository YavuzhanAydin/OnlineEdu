using AutoMapper;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.RoleDtos;
using OnlineEdu.DTO.DTOs.UserDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEduAPI.Mapping
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<AppUser,RegisterDto>().ReverseMap();

            CreateMap<AppRole, ResultRoleDto>().ReverseMap();
            CreateMap<AppRole, UpdateRoleDto>().ReverseMap();
            CreateMap<AppRole, CreateRoleDto>().ReverseMap();
            CreateMap<AppUser, ResultUserDto>().ReverseMap();
        }
    }
}
