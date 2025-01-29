using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BlogCategoryDtos;
using OnlineEdu.WebUI.Models;

namespace OnlineEdu.WebUI.ViewComponents.Blog
{
    public class _BlogCategoryListComponent : ViewComponent
    {

        private readonly HttpClient _client;
        public _BlogCategoryListComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categoryList = await _client.GetFromJsonAsync<List<ResultsBlogCategoryDto>>("blogCategories");

            var blogCategories = (from blogCategory in categoryList 
                                  select new BlogCategoryWithCountViewModel
                                  {
                                      CategoryName = blogCategory.Name,
                                      BlogCount = blogCategory.Blogs.Count,
                                      BlogCategoryId = blogCategory.BlogCategoryID
                                  }).ToList();

            return View(blogCategories);
        }



    }
}
