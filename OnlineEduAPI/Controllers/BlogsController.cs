using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.Business.Abstract;
using OnlineEdu.DTO.DTOs.AboutDtos;
using OnlineEdu.DTO.DTOs.BlogDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEduAPI.Controllers
{
    [Authorize(Roles = "Admin, Teacher")]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController(IBlogService _blogService,IMapper _mapper) : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            var values = _blogService.TGetBlogsWithCategories();
            var mappedValues = _mapper.Map<List<ResultsBlogDto>>(values);
            return Ok(mappedValues);
        }
        [AllowAnonymous]
        [HttpGet("GetLast4Blogs")]
        public  IActionResult GetLast4Blogs(int id)
        {
            var values = _blogService.TGetLast4BlogsWithCategories();
            var mappedValues = _mapper.Map<List<ResultsBlogDto>>(values);
            return Ok(mappedValues);

        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var value = _blogService.TGetBlogWithCategory(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _blogService.TDelete(id);
            return Ok("Blog Alanı Kaldırıldı");
        }


        [HttpPost]
        public IActionResult Create(CreateBlogDto createBlogDto)
        {
            var newvalue = _mapper.Map<Blog>(createBlogDto);
            _blogService.TCreate(newvalue);
            return Ok("Yeni Blog Alanı Eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateBlogDto updateBlogDto)
        {
            var value = _mapper.Map<Blog>(updateBlogDto);
            _blogService.TUpdate(value);
            return Ok("Blog Alanı Güncellendi");

        }
        [AllowAnonymous]
        [HttpGet("GetBlogByWriterId/{id}")]
        public IActionResult GetBlogByWriterId(int id)
        {
            var values = _blogService.TGetBlogsWithCategoriesByWriterId(id);
            var mappedValues = _mapper.Map<List<ResultsBlogDto>>(values);
            return Ok(mappedValues);
        }

        [AllowAnonymous]
        [HttpGet("GetBlogCount")]
        public IActionResult GetBlogCount()
        {
            var blogCount = _blogService.TCount();
            return Ok(blogCount);

        }
        [AllowAnonymous]
        [HttpGet("GetBlogsByCategoryId/{id}")]
        public IActionResult GetBlogsByCategoryId(int id)
        {
            var blogs = _blogService.TGetBlogsByCategoryId(id);
            return Ok(blogs);

        }

    }
}
