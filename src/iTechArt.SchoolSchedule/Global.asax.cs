using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;
using iTechArt.Common.Logging;
using Unity.Lifetime;

namespace iTechArt.SchoolSchedule
{
    public class MvcApplication : HttpApplication
    { 
        protected void Application_Start()
        {
            UnityConfig.RegisterComponents();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}