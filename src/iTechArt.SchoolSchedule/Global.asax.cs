using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using iTechArt.Common.Logging;
using Unity;
using Unity.Resolution;

namespace iTechArt.SchoolSchedule
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            UnityConfig.RegisterComponents();
            ConfigureLogging();
        }


        private void ConfigureLogging()
        {
            LoggerContext.Current = UnityConfig.UnityContainer.Resolve<Logger>(
                new ParameterOverride("name", "iTechArt.SchoolSchedule logger"));
        }
    }
}