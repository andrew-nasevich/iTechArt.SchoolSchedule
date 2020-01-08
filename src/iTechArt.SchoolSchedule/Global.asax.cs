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
        private static readonly IUnityContainer _unityContainer = new UnityContainer();


        protected void Application_Start()
        {
            FillContainer();

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private static void FillContainer()
        {
            _unityContainer.RegisterType<ILogger, Logger>(new ContainerControlledLifetimeManager());
        }
    }
}