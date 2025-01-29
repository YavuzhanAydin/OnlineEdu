using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.ContactDtos;
using OnlineEdu.WebUI.DTOs.MessagesDtos;
using OnlineEdu.WebUI.Helpers;

namespace OnlineEdu.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly HttpClient _client;

        public ContactController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }
        public async Task<IActionResult> IndexAsync()
		{
			var values = await _client.GetFromJsonAsync<List<ResultsContactDto>>("contacts");
			ViewBag.ContactMap = values.Select(x => x.MapURL).FirstOrDefault();
			return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            await _client.PostAsJsonAsync("messages", createMessageDto);
            return NoContent();

        }

        public async Task<PartialViewResult> ContactMap()
        {
           
            return PartialView();

        }


    }
}
