using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.WebUI.Areas.Students.Controllers
{
    [Area("Students")]
    public class StudentsLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
