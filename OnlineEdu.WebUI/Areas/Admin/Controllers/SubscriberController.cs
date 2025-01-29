using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.SubscribersDtos;
using OnlineEdu.WebUI.Helpers;
using System.Drawing.Printing;

namespace OnlineEdu.WebUI.Areas.Admin.Controllers
{
	[Authorize(Roles = "Admin")]
	[Area("Admin")]
    public class SubscriberController : Controller
    {
        private readonly HttpClient _client;

        public SubscriberController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }
        public async Task<IActionResult> Index()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSubscriberDto>>("subscribers");
            return View(values);
        }

        public async Task<IActionResult> DeleteSubscriber(int id)
        {
            await _client.DeleteAsync($"subscribers/{id}");
            return RedirectToAction(nameof(Index));

        }

       

        public async Task<IActionResult> ChangeStatusSubscriber(int id)
        {
            var values = await _client.GetFromJsonAsync<UpdateSubscriberDto>($"subscribers/{id}");
            if (values.IsActive)
            {
                values.IsActive = false;
            }
            else 
            { 
            
            values.IsActive = true;
            }
            await _client.PutAsJsonAsync("subscribers", values);
            return RedirectToAction("Index");
        }





    }
}
