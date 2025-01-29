using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BlogDtos;
using OnlineEdu.WebUI.DTOs.SubscribersDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClient _client;

        public BlogController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(CreateSubscriberDto model)
        {
            await _client.PostAsJsonAsync("subscribers", model);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> BlogDetails(int id)
        {
            var blog = await _client.GetFromJsonAsync<ResultsBlogDto>("blogs/"+ id);
            return View(blog);
        }

        public async Task<IActionResult> BlogsByCategory(int id)
        {
            var blogs = await _client.GetFromJsonAsync<List<ResultsBlogDto>>("blogs/GetBlogsByCategoryId/" + id);

            ViewBag.CategoryName = blogs.Select(x=>x.BlogCategory.Name).FirstOrDefault();

            return View(blogs);

        }

    }
}
