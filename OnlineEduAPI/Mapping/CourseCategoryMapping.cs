using AutoMapper;
using OnlineEdu.DTO.DTOs.CourseCategoriesDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEduAPI.Mapping
{
    public class CourseCategoryMapping : Profile
    {
        public CourseCategoryMapping()
        {
            CreateMap<CreateCourseCategoriesDto , CourseCategory>().ReverseMap();
            CreateMap<UpdateCourseCategoriesDto , CourseCategory>().ReverseMap();
            CreateMap<ResultCourseCategoriesDto , CourseCategory>().ReverseMap();
        }
    }
}
