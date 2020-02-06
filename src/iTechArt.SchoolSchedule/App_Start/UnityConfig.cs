using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using iTechArt.Repositories.Interfaces;
using iTechArt.SchoolSchedule.Foundation.SchoolScheduleInitializationService;
using iTechArt.SchoolSchedule.Foundation.Interfaces;
using iTechArt.SchoolSchedule.Repositories.DbContexts;
using iTechArt.SchoolSchedule.Repositories.Interfaces;
using iTechArt.SchoolSchedule.Repositories.SchoolScheduleUnitOfWorks;

namespace iTechArt.SchoolSchedule
{
    public static class UnityConfig
    {
        public static IUnityContainer UnityContainer { get; } = new UnityContainer();


        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IUnitOfWork, SchoolScheduleUnitOfWork>();
            container.RegisterType<ISchoolScheduleUnitOfWorkFactory, SchoolScheduleUnitOfWorkFactory>();
            container.RegisterType<ISchoolScheduleInitializationService, SchoolScheduleInitializationService>();
            container.RegisterType<ISchoolScheduleContextFactory, SchoolScheduleContextFactory>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}