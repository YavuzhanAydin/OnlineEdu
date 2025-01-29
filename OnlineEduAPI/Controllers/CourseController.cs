using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEduAPI.Controllers
{
    [Authorize(Roles = "Admin,  Student, Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController(ICourseService _courseService,IMapper _mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var values = _courseService.TGetAllCourseWithCategories();
            var course = _mapper.Map<List<ResultCourseDto>>(values);
            return Ok(course);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _courseService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseService.TDelete(id);
            return Ok("Kurs Alanı Kaldırıldı");
        }
        [HttpPost]
        public IActionResult Create(CreateCourseDto createCourseDto)
        {
            var newvalue = _mapper.Map<Course>(createCourseDto);
            _courseService.TCreate(newvalue);
            return Ok("Yeni Kurs Alanı Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateCourseDto updateCourseDto)
        {
            var value = _mapper.Map<Course>(updateCourseDto);
            _courseService.TUpdate(value);
            return Ok("Kurs Alanı Güncellendi");

        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _courseService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");
        }



        [HttpGet("DontShowOnHome/{id}")]
        public IActionResult DontShowOnHome(int id)
        {
            _courseService.TDontShowOnHome(id);
            return Ok("Ana Sayfada Gösterilmiyor");
        }
        [AllowAnonymous]
        [HttpGet("GetActiveCourse")]
        public IActionResult GetActiveCourse()
        {
            var values = _courseService.TGetFilteredList(x => x.IsShown == true);
            return Ok(values);
        }

        [HttpGet("GetCourseByTeacherId/{id}")]
        public IActionResult GetCourseByTeacherId(int id)
        {
            var values = _courseService.TGetCourseByTeacherId(id);
            var mappedValues = _mapper.Map<List<ResultCourseDto>>(values);
            
            return Ok(mappedValues);
        }
        [AllowAnonymous]
        [HttpGet("GetCourseCount")]
        public IActionResult GetCourseCount()
        {
            var CourseCount = _courseService.TCount();
            return Ok(CourseCount);

        }
        [AllowAnonymous]
		[HttpGet("GetCourseByCategoryID/{id}")]
		public IActionResult GetCourseByCategoryID(int id)
		{
            var values = _courseService.TGetAllCourseWithCategories(x=>x.CourseCategoryID==id);
			return Ok(values); 
		}


	}
}
