using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.WebUI.DTOs.CourseDtos;
using OnlineEdu.WebUI.DTOs.CourseRegisterDtos;
using OnlineEdu.WebUI.DTOs.CourseVideoDtos;
using OnlineEdu.WebUI.Services.TokenServices;

namespace OnlineEdu.WebUI.Areas.Students.Controllers
{
    [Authorize(Roles ="Student")]
    [Area("Students")]
    public class CourseRegisterController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;
        public CourseRegisterController(IHttpClientFactory clientFactory, ITokenService tokenService)
        {
            _client = clientFactory.CreateClient("EduClient");
            _tokenService = tokenService;
        }
        public async Task<IActionResult> Index()
        {
            var userId = _tokenService.GetUserId;

            var value = await _client.GetFromJsonAsync<List<ResultCourseRegisterDto>>("courseRegisters/GetMyCourses/"+ userId);
            return View(value);
        }

        [HttpGet] 
        public async Task<IActionResult> RegisterCourse()
        {
            var courseList = await _client.GetFromJsonAsync<List<ResultCourseDto>>("course");

            ViewBag.courses = (from x in courseList
                                            select new SelectListItem
                                            {
                                                Text = x.CourseName,
                                                Value = x.CourseID.ToString()
                                            }).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterCourse(CreateCourseRegisterDto model)
        {
			var courseList = await _client.GetFromJsonAsync<List<ResultCourseDto>>("course");

			ViewBag.courses = (from x in courseList
							   select new SelectListItem
							   {
								   Text = x.CourseName,
								   Value = x.CourseID.ToString()
							   }).ToList();

            var userId = _tokenService.GetUserId;
            model.AppUserID = userId;
            var result= await _client.PostAsJsonAsync("courseRegisters", model);
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        
        
        }


        public async Task<IActionResult> CourseVideos(int id)
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseDtos>>("courseVideos/GetCourseVideosByCourseID/" + id);
            ViewBag.courseName= values.Select(x=>x.Course.CourseName).FirstOrDefault();
            return View(values);
        }

    }
}
