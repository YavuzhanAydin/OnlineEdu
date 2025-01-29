using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.ContactDtos;
using OnlineEdu.WebUI.DTOs.CourseCategoriesDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]

    public class CourseCategoryController : Controller
    {
        private readonly HttpClient _client;

        public CourseCategoryController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultCourseCategoriesDto>>("courseCategories");
            return View(values);
        }

        public async Task<IActionResult> DeleteCourseCategory(int id)
        {
            await _client.DeleteAsync($"courseCategories/{id}");
            return RedirectToAction(nameof(Index));

        }

        public IActionResult CreateCourseCategory()
        {
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseCategory(CreateCourseCategoriesDto createCourseCategoriesDto)
        {
            await _client.PostAsJsonAsync("courseCategories", createCourseCategoriesDto);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> UpdateCourseCategory(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateCourseCategoriesDto>($"courseCategories/{id}");

            return View(values);
        }



        [HttpPost]
        public async Task<IActionResult> UpdateCourseCategory(UpdateCourseCategoriesDto updateCourseCategoryDto)
        {
            await _client.PutAsJsonAsync("courseCategories", updateCourseCategoryDto);
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> ShowOnHome(int id)
        {
            await _client.GetAsync("courseCategories/ShowOnHome/" + id);
            return RedirectToAction(nameof(Index));

        }

		public async Task<IActionResult> DontShowOnHome(int id)
		{
			await _client.GetAsync("courseCategories/DontShowOnHome/" + id);
			return RedirectToAction(nameof(Index));

		}
	}
}
