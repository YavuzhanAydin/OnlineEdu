using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using OnlineEdu.WebUI.DTOs.CourseCategoriesDtos;
using OnlineEdu.WebUI.DTOs.CourseDtos;
using OnlineEdu.WebUI.DTOs.CourseVideoDtos;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Services.TokenServices;

namespace OnlineEdu.WebUI.Areas.Teacher.Controllers
{
	[Authorize(Roles ="Teacher")]
	[Area("Teacher")]
	public class MyCourseController : Controller
	{
        private readonly HttpClient _client;

        private readonly ITokenService _tokenService;

        public MyCourseController(IHttpClientFactory clientFactory, ITokenService tokenService)
        {
            _client = clientFactory.CreateClient("EduClient");
            _tokenService = tokenService;
        }

        

		public async Task<IActionResult> Index()
		{
			var userId = _tokenService.GetUserId;
			var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("course/GetCourseByTeacherId/" + userId);
			return View(values);
		}

		public  async Task<IActionResult> CreateCourse()
		{
			var categoryList = await _client.GetFromJsonAsync<List<ResultCourseCategoriesDto>>("courseCategories");
			List<SelectListItem> categories = (from x in categoryList
											   select new SelectListItem
											   {
												   Text = x.Name,
												   Value = x.CourseCategoryID.ToString()
											   }).ToList();
			ViewBag.categories = categories;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateCourse(CreateCourseDto createCourseDto)
		{
            var userId = _tokenService.GetUserId;
            createCourseDto.AppUserId = userId;
			createCourseDto.IsShown = false;
			await _client.PostAsJsonAsync("course", createCourseDto);
			return RedirectToAction("Index");
			
		}

		public async Task<IActionResult> DeleteCourse(int id)
		{
			await _client.DeleteAsync("course/"+id);
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> UpdateCourse(int id)
		{
            var categoryList = await _client.GetFromJsonAsync<List<ResultCourseCategoriesDto>>("courseCategories");
            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.Name,
                                                   Value = x.CourseCategoryID.ToString()
                                               }).ToList();
            ViewBag.categories = categories;

            var value = await _client.GetFromJsonAsync<UpdateCourseDto>("course/" + id);
			return View(value);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateCourse(UpdateCourseDto updateCourseDto)
		{
            var userId = _tokenService.GetUserId;
            updateCourseDto.AppUserId = userId;
			await _client.PutAsJsonAsync("course", updateCourseDto);
			return RedirectToAction("Index"); 
		}
		public async Task<IActionResult> CourseVideos(int id)
		{
			var values = await _client.GetFromJsonAsync<List<ResultCourseDtos>>("courseVideos/GetCourseVideosByCourseID/" + id);

			TempData["courseId"] = id;
			
			ViewBag.courseName = values.Select(x => x.Course.CourseName).FirstOrDefault();
			return View(values);
		}
		[HttpGet]
		public async Task<IActionResult> CreateVideo()
		{
			var courseId = (int)TempData["courseId"];
			var course = await _client.GetFromJsonAsync<ResultCourseDto>("course/" + courseId);
			ViewBag.courseName = course.CourseName;
			ViewBag.courseId = course.CourseID;
			
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateVideo(CreateCourseVideoDtos model)
		{
			
			await _client.PostAsJsonAsync("courseVideos", model);
			
			return RedirectToAction("Index");
		}

	}
}
