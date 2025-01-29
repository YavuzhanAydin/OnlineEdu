using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.WebUI.DTOs.CourseCategoriesDtos;
using OnlineEdu.WebUI.DTOs.CourseDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]

	public class CourseController : Controller
	{
        private readonly HttpClient _client;

        public CourseController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task CourseCategoryDropdown()
		{
			var courseCategoryList = await _client.GetFromJsonAsync<List<ResultCourseCategoriesDto>>("courseCategories");
			List<SelectListItem> courseCategories = (from x in courseCategoryList
													 select new SelectListItem
													 {
														 Text = x.Name,
														 Value = x.CourseCategoryID.ToString()

													 }).ToList();
			ViewBag.courseCategories = courseCategories;
		}



		public async Task<IActionResult> Index()
		{
			var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("course");
			
			return View(values);
		}

		public async Task<IActionResult> DeleteCourse(int id)
		{
			await _client.DeleteAsync($"course/{id}");
			return RedirectToAction(nameof(Index));

		}

		public async Task<IActionResult> CreateCourse()
		{
			await CourseCategoryDropdown();
			return View();

		}

		[HttpPost]
		public async Task<IActionResult> CreateCourse(CreateCourseDto createCourseDto)
		{
			await _client.PostAsJsonAsync("course", createCourseDto);
			return RedirectToAction(nameof(Index));

		}

		public async Task<IActionResult> UpdateCourse(int id)
		{
			var values = await _client.GetFromJsonAsync<UpdateCourseDto>($"course/{id}");

			return View(values);
		}



		[HttpPost]
		public async Task<IActionResult> UpdateCourse(UpdateCourseDto updateCourseDto)
		{
			await _client.PutAsJsonAsync("course", updateCourseDto);
			return RedirectToAction(nameof(Index));

		}

		public async Task<IActionResult> ShowOnHome(int id)
		{
			await _client.GetAsync("course/ShowOnHome/" + id);
			return RedirectToAction(nameof(Index));

		}


        public async Task<IActionResult> DontShowOnHome(int id)
        {
            await _client.GetAsync("course/DontShowOnHome/" + id);
            return RedirectToAction(nameof(Index));

        }
    }
}
