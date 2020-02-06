using System.Threading.Tasks;
using System.Web.Mvc;
using iTechArt.SchoolSchedule.Foundation.Interfaces;

namespace iTechArt.SchoolSchedule.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISchoolScheduleInitializationService _schoolScheduleInitializationService;


        public HomeController(ISchoolScheduleInitializationService schoolScheduleInitializationService)
        {
            _schoolScheduleInitializationService = schoolScheduleInitializationService;
        }


        public string Index()
        {
            return "Hello, World!";
        }

        [HttpPost]
        public async Task<string> Initialize()
        {
            await _schoolScheduleInitializationService.InitializeAsync();

            return "Done";
        }
    }
}