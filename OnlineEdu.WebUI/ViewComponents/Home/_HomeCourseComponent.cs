using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.CourseDtos;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.ViewComponents.Home
{
    public class _HomeCourseComponent : ViewComponent
    {
        private readonly HttpClient _client;
        public _HomeCourseComponent(IHttpClientFactory clientFactory, IUserService _userService)
        {
            _client = clientFactory.CreateClient("EduClient");

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var values = await _client.GetFromJsonAsync<List<ResultCourseDto>>("course/GetActiveCourse");

            return View(values);
        }

    }
}
