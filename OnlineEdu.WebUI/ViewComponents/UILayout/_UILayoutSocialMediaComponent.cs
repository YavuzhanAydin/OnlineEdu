using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.SocialMediaDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.UILayout
{
	public class _UILayoutSocialMediaComponent : ViewComponent
	{
        private readonly HttpClient _client;
        public _UILayoutSocialMediaComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");

        }
        public async Task<IViewComponentResult> InvokeAsync()
		{
			var socials = await _client.GetFromJsonAsync<List<ResultSocialMediaDto>>("socialMedia");

			return View(socials);
		}

	}
}
