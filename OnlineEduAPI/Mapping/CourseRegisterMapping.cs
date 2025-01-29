using AutoMapper;
using OnlineEdu.DTO.DTOs.CourseRegisterDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEduAPI.Mapping
{
    public class CourseRegisterMapping : Profile
    {
        public CourseRegisterMapping()
        {
            CreateMap<CourseRegister,ResultCourseRegister>().ReverseMap();
            CreateMap<CourseRegister,CreateCourseRegister>().ReverseMap();
            CreateMap<CourseRegister,UpdateCourseRegister>().ReverseMap();


        }
    }
}
