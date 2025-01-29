using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.CourseCategoriesDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEduAPI.Controllers
{
    [Authorize(Roles = "Admin, Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseCategoriesController(ICourseCategoryService _courseCategoryService, IMapper _mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var values = _courseCategoryService.TGetList();
            var courseCategories = _mapper.Map<List<ResultCourseCategoriesDto>>(values);
            return Ok(courseCategories);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _courseCategoryService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _courseCategoryService.TDelete(id);
            return Ok("Kurs Kategori Alanı Kaldırıldı");
        }
        [HttpPost]
        public IActionResult Create(CreateCourseCategoriesDto createCourseCategoriesDto)
        {
            var newvalue = _mapper.Map<CourseCategory>(createCourseCategoriesDto);
            _courseCategoryService.TCreate(newvalue);
            return Ok("Yeni Kurs Kategori Alanı Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateCourseCategoriesDto updateCourseCategoriesDto)
        {
            var value = _mapper.Map<CourseCategory>(updateCourseCategoriesDto);
            _courseCategoryService.TUpdate(value);
            return Ok("Kurs Kategori Alanı Güncellendi");

        }

        [HttpGet("ShowOnHome/{id}")]
        public IActionResult ShowOnHome(int id)
        {
            _courseCategoryService.TShowOnHome(id);
            return Ok("Ana Sayfada Gösteriliyor");

        }


		[HttpGet("DontShowOnHome/{id}")]
		public IActionResult DontShowOnHome(int id)
		{
			_courseCategoryService.TDontShowOnHome(id);
			return Ok("Ana Sayfada Gösterilmiyor!");

		}

        [AllowAnonymous]
        [HttpGet("GetActiveCategories")]
        public IActionResult GetActiveCategories()
        {
            var values = _courseCategoryService.TGetFilteredList(x => x.IsShown == true);
            return Ok(values);
        }
        [AllowAnonymous]
        [HttpGet("GetCourseCategoryCount")]
        public IActionResult GetCourseCount()
        {
            var CourseCategoryCount = _courseCategoryService.TCount();
            return Ok(CourseCategoryCount);

        }

    }
}
