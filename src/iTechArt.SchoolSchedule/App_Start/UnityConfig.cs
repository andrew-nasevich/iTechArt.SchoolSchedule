using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace iTechArt.SchoolSchedule
{
    public static class UnityConfig
    {
        public static IUnityContainer UnityContainer { get; } = new UnityContainer();


        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}