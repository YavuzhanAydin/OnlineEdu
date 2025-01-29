using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.CourseRegisterDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEduAPI.Controllers
{
    [Authorize(Roles = "Admin, Student, Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseRegistersController(ICourseRegisterService _courseRegisterService,IMapper _mapper) : Controller
    {
        [HttpGet("GetMyCourses/{id}")]
        public IActionResult GetMyCourses(int id)
        {
            var value = _courseRegisterService.TGetAllWithCourseAndCategory(x => x.AppUserID == id);
            var valueMapping = _mapper.Map<List<ResultCourseRegister>>(value);
            return Ok(valueMapping);
        }

        [HttpPost]
        public IActionResult RegisterToCourse(CreateCourseRegister model)
        {
            var newCourseRegister = _mapper.Map<CourseRegister>(model);
            _courseRegisterService.TCreate(newCourseRegister);
            return Ok("Kursa Kayıtlı Başarılı");
        }

        [HttpPut]
        public IActionResult UpdateCourseRegister(UpdateCourseRegister model)
        {
            var updateModel = _mapper.Map<CourseRegister>(model);
            _courseRegisterService.TUpdate(updateModel);
            return Ok("Kurs Kaydı Güncellendi");  

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var value = _courseRegisterService.TGetById(id);
            var mappedValue = _mapper.Map<CourseRegister>(value);
            return Ok(mappedValue);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCourseRegister(int id)
        {

            _courseRegisterService.TDelete(id);

            return Ok("Kurs Başarılı Şekilde Silinmiştir");  
        }


    }
}
