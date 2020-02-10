using System.Web.Mvc;
using iTechArt.SchoolSchedule.Foundation.InitializationServices;
using Unity;
using Unity.Mvc5;
using iTechArt.SchoolSchedule.Foundation.Interfaces;
using iTechArt.SchoolSchedule.Repositories.Interfaces;
using iTechArt.SchoolSchedule.Repositories.SchoolScheduleUnitOfWorks;
using Unity.Lifetime;

namespace iTechArt.SchoolSchedule
{
    public static class UnityConfig
    {
        public static IUnityContainer UnityContainer { get; } = new UnityContainer();


        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<ISchoolScheduleUnitOfWorkFactory, SchoolScheduleUnitOfWorkFactory>();
            container.RegisterType<ISchoolScheduleInitializationService, SchoolScheduleInitializationService>(new ContainerControlledLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}