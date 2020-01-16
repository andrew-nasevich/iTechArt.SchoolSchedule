using System.Web.Mvc;
using iTechArt.SchoolSchedule.Repositories.UnitsOfWork;
using iTechArt.SchoolSchedule.Repositories.DbContexts;
using iTechArt.SchoolSchedule.DomainModel.Models.Lessons;
using iTechArt.SchoolSchedule.DomainModel.Models.People;

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