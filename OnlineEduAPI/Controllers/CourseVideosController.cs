using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseVideoDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEduAPI.Controllers
{
    [Authorize(Roles = "Admin,  Student, Teacher")]
    [Route("api/[controller]")]
	[ApiController]
	public class CourseVideosController(IGenericService<CourseVideo> _courseVideoService,IMapper _mapper) : ControllerBase
	{
		[HttpGet]

		public IActionResult Get()
		{
			var values = _courseVideoService.TGetList();
			return Ok(values);
		}

		[HttpGet("GetCourseVideosByCourseID/{id}")]

		public IActionResult GetCourseVideosByCourseID(int id)
		{
			var values = _courseVideoService.TGetFilteredList(x => x.CourseId == id);
			return Ok(values);
		}
		[HttpGet("{id}")]
		public IActionResult GetByID(int id)
		{
			var value = _courseVideoService.TGetById(id);
			return Ok(value);
		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			_courseVideoService.TDelete(id);
			return Ok("Video  Kaldırıldı");
		}
		[HttpPost]
		public IActionResult Create(CreateCourseVideoDtos createCourseVideoDtos)
		{
			var newvalue = _mapper.Map<CourseVideo>(createCourseVideoDtos);
			_courseVideoService.TCreate(newvalue);
			return Ok("Yeni Video Eklendi");
		}

		[HttpPut]
		public IActionResult Update(UpdateCourseVideoDtos updateCourseVideoDtos)
		{
			var value = _mapper.Map<CourseVideo>(updateCourseVideoDtos);
			_courseVideoService.TUpdate(value);
			return Ok("Video Güncellendi");

		}
	}
}
