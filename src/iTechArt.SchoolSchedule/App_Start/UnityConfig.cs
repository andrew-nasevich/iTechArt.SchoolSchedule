using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace iTechArt.SchoolSchedule
{
    public static class UnityConfig
    {
        private static readonly IUnityContainer _unityContainer = new UnityContainer();


        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}