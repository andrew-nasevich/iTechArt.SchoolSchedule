using System.Threading.Tasks;
using System.Web.Mvc;
using iTechArt.SchoolSchedule.Foundation.Interfaces;

namespace iTechArt.SchoolSchedule.Controllers
{
    public class InitializationController : Controller
    {
        private readonly ISchoolScheduleInitializationService _schoolScheduleInitializationService;

        public InitializationController(ISchoolScheduleInitializationService schoolScheduleInitializationService)
        {
            _schoolScheduleInitializationService = schoolScheduleInitializationService;
        }


        [HttpPost]
        public async Task<string> Initialize()
        {
            await _schoolScheduleInitializationService.InitializeAsync();

            return "Done";
        }
    }
}