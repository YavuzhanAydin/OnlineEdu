using AutoMapper;
using OnlineEdu.DTO.DTOs.CourseVideoDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEduAPI.Mapping
{
	public class CourseVideoMapping :Profile
	{
		public CourseVideoMapping()
		{
			CreateMap<CreateCourseVideoDtos, CourseVideo>().ReverseMap();
			CreateMap<UpdateCourseVideoDtos, CourseVideo>().ReverseMap();
			CreateMap<ResultCourseVideoDtos, CourseVideo>().ReverseMap();
		}
	}
}
