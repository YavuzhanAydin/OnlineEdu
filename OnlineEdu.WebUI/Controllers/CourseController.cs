using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.CourseDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Controllers
{
	public class CourseController : Controller
	{
        private readonly HttpClient _client;

        public CourseController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }
        public async Task<IActionResult> Index()
		{
			var courses = await _client.GetFromJsonAsync<List<ResultCourseDto>>("course");
			return View(courses);
		}

		public async Task<IActionResult> GetCourseByCategoryID(int id)
		{
			var courses = await _client.GetFromJsonAsync<List<ResultCourseDto>>("course/GetCourseByCategoryID/" + id);
			var category = (from x in courses 
							select x.Category.Name).FirstOrDefault();
			ViewBag.category=category;

			return View(courses);
			
		}


	}
}
