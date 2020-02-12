using System.Web.Mvc;
using Unity;
using Unity.Lifetime;
using Unity.AspNet.Mvc;
using UnityDependencyResolver = Unity.Mvc5.UnityDependencyResolver;
using iTechArt.SchoolSchedule.Foundation.Interfaces;
using iTechArt.SchoolSchedule.Repositories.Interfaces;
using iTechArt.SchoolSchedule.Repositories.SchoolScheduleUnitOfWorks;
using iTechArt.SchoolSchedule.Foundation.InitializationServices;

namespace iTechArt.SchoolSchedule
{
    public static class UnityConfig
    {
        public static IUnityContainer UnityContainer { get; } = new UnityContainer();


        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<ISchoolScheduleUnitOfWorkFactory, SchoolScheduleUnitOfWorkFactory>(new ContainerControlledLifetimeManager());
            container.RegisterType<ISchoolScheduleInitializationService, SchoolScheduleInitializationService>(new PerRequestLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}