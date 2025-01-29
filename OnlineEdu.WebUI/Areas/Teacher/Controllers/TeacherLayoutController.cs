using Microsoft.AspNetCore.Mvc;

namespace OnlineEdu.WebUI.Areas.Teacher.Controllers
{
    public class TeacherLayoutController : Controller
    {
        [Area("Teacher")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
