using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineEdu.WebUI.DTOs.BlogCategoryDtos;
using OnlineEdu.WebUI.DTOs.BlogDtos;
using OnlineEdu.WebUI.Services.TokenServices;

namespace OnlineEdu.WebUI.Areas.Teacher.Controllers
{
    [Authorize(Roles ="Teacher")]
    [Area("Teacher")]
    public class MyBlogController : Controller
    {
        private readonly HttpClient _client;
        private readonly ITokenService _tokenService;
        public MyBlogController(IHttpClientFactory clientFactory, ITokenService tokenService)
        {
            _client = clientFactory.CreateClient("EduClient");
            _tokenService = tokenService;
        }

        public async  Task<IActionResult> Index()
        {
            var userId = _tokenService.GetUserId;

            var values = await _client.GetFromJsonAsync<List<ResultsBlogDto>>("blogs/GetBlogByWriterId/"+userId);
            return View(values);
        }
    
        public async Task BlogCategoryDropDownListAsync()
        {
            var categoryList = await _client.GetFromJsonAsync<List<ResultsBlogCategoryDto>>("blogCategories");
            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {

                                                   Text = x.Name,
                                                   Value = x.BlogCategoryID.ToString()
                                               }).ToList();
            ViewBag.categories = categories;


        }


        public async Task<IActionResult> CreateBlog()
        {

            await BlogCategoryDropDownListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {
            var userId = _tokenService.GetUserId;
            createBlogDto.WriterID = userId;
            await _client.PostAsJsonAsync("blogs", createBlogDto);
            return RedirectToAction("Index");


		}

        public async Task<IActionResult> UpdateBlog(int id)
        {
            await BlogCategoryDropDownListAsync();
            var values = await _client.GetFromJsonAsync<UpdateBlogDto>("blogs/" + id);
            return View(values);

        }
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)
        {

            await _client.PutAsJsonAsync("blogs", updateBlogDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _client.DeleteAsync("blogs/" + id);
            return RedirectToAction("Index");
        }

	}
}
