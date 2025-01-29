using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BlogDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.Blog
{
    public class _BlogRecentBlogsComponent : ViewComponent
    {

        private readonly HttpClient _client;
        public _BlogRecentBlogsComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultsBlogDto>>("blogs/GetLast4Blogs");

            return View(values);

        }
    

    }
}
