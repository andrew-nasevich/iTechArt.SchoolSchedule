using System.Web.Mvc;

namespace iTechArt.SchoolSchedule.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public string Index()
        {
            return "Hello, World!";
        }
    }
}