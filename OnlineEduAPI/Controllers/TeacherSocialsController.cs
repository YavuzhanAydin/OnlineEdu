using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.TeacherSocialDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEduAPI.Controllers
{
    [Authorize(Roles = "Admin, Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherSocialsController(IGenericService<TeacherSocial> _teacherSocialService , IMapper _mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("byTeacherId/{id}")]
        public IActionResult GetSocialByTeacherId(int id)
        {
            var values = _teacherSocialService.TGetFilteredList(x=>x.TeacherId == id);
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _teacherSocialService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _teacherSocialService.TDelete(id);
            return Ok("Sosyal Medya Alanı Kaldırıldı");
        }
        [HttpPost]
        public IActionResult Create(CreateTeacherSocialDto createTeacherSocialDto)
        {
            var newvalue = _mapper.Map<TeacherSocial>(createTeacherSocialDto);
            _teacherSocialService.TCreate(newvalue);
            return Ok("Yeni Sosyal Medya Alanı Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateTeacherSocialDto updateTeacherSocialDto)
        {
            var value = _mapper.Map<TeacherSocial>(updateTeacherSocialDto);
            _teacherSocialService.TUpdate(value);
            return Ok("Sosyal Medya Alanı Güncellendi");

        }



    }
}
