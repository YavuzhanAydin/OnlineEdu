using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.ContactDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.ViewComponents.Contact
{
    public class _ContactİnfoComponent : ViewComponent
    {

        private readonly HttpClient _client;
        public _ContactİnfoComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var contact = await _client.GetFromJsonAsync<List<ResultsContactDto>>("contacts");
            return View(contact);
        }
    }
}
