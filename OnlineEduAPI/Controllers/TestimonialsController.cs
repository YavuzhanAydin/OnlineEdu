using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.TestimonialDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEduAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController(IGenericService<Testimonial> _testimonialService,IMapper _mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]

        public IActionResult Get()
        {
            var values = _testimonialService.TGetList();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _testimonialService.TGetById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _testimonialService.TDelete(id);
            return Ok("Referans Alanı Kaldırıldı");
        }
        [HttpPost]
        public IActionResult Create(CreateTestimonialDto CreateTestimonialDto)
        {
            var newvalue = _mapper.Map<Testimonial>(CreateTestimonialDto);
            _testimonialService.TCreate(newvalue);
            return Ok("Yeni Referans Alanı Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateTestimonialDto updateTestimonialDto)
        {
            var value = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(value);
            return Ok("Referans Alanı Güncellendi");

        }
        [AllowAnonymous]
        [HttpGet("GetTestimonialCount")]
        public IActionResult GetTestimonialCount()
        {
            var testimonialCount = _testimonialService.TCount();
            return Ok(testimonialCount);

        }
    }
}
