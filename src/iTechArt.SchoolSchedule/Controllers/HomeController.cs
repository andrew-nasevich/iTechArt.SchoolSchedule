using iTechArt.SchoolSchedule.DomainModel.People;
using iTechArt.SchoolSchedule.DomainModel.Rooms;
using iTechArt.SchoolSchedule.Repositories.DbContexts;
using iTechArt.SchoolSchedule.Repositories.UnitsOfWork;
using System.Web.Mvc;

namespace iTechArt.SchoolSchedule.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "Hello, World!";
        }
    }
}