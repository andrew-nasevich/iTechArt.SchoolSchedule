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
            var context = new SchoolScheduleContext();
            var uow = new SchoolScheduleUnitOfWork(context);
            var rep = uow.GetRepository<Classroom>();
            var c = new Classroom {Id = 1, Name = "1"};
            rep.Add(c);
            var people = rep.GetAllAsync().Result;
            return "Hello, World!";
        }
    }
}