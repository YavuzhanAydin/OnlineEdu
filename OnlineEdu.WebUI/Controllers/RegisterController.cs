using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.UserDtos;
using OnlineEdu.WebUI.Helpers;
using OnlineEdu.WebUI.Services.UserServices;

namespace OnlineEdu.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly HttpClient _client;

        public RegisterController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }
        public IActionResult SingUp()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> SingUp(UserRegisterDto userRegisterDto)
        {
            var result = await _client.PostAsJsonAsync("users/register", userRegisterDto);
            if (!ModelState.IsValid)
            {
                return View(userRegisterDto);

            }


            if (!result.IsSuccessStatusCode)
            {
                var errors = await result.Content.ReadFromJsonAsync<List<RegisterResponseDto>>();

                foreach (var item in errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            return RedirectToAction("SignIn","Login");
        }
    }
}
