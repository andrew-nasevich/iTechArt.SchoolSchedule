using System.Web.Mvc;
using iTechArt.SchoolSchedule.DomainModel.Users;
using Unity;
using Unity.Lifetime;
using Unity.AspNet.Mvc;
using UnityDependencyResolver = Unity.Mvc5.UnityDependencyResolver;
using iTechArt.SchoolSchedule.Foundation.Interfaces;
using iTechArt.SchoolSchedule.Repositories.Interfaces;
using iTechArt.SchoolSchedule.Repositories.SchoolScheduleUnitOfWorks;
using iTechArt.SchoolSchedule.Foundation.InitializationServices;
using iTechArt.SchoolSchedule.Foundation.SchoolScheduleManagers;
using iTechArt.SchoolSchedule.Repositories.SchoolScheduleStores;

namespace iTechArt.SchoolSchedule.App_Start
{
    public static class UnityConfig
    {
        public static IUnityContainer UnityContainer { get; } = new UnityContainer();


        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<ISchoolScheduleUnitOfWorkFactory, SchoolScheduleUnitOfWorkFactory>(new ContainerControlledLifetimeManager());
            container.RegisterType<ISchoolScheduleInitializationService, SchoolScheduleInitializationService>(new PerRequestLifetimeManager());
            container.RegisterType<ISchoolScheduleUserStore<SchoolScheduleUser>, SchoolScheduleUserStore<SchoolScheduleUser>>(new PerRequestLifetimeManager());
            container.RegisterType<ISchoolScheduleUserManager, SchoolScheduleUserManager>(new PerRequestLifetimeManager());
            container.RegisterType<ISchoolScheduleRoleStore<SchoolScheduleRole>, SchoolScheduleRoleStore<SchoolScheduleRole>>(new PerRequestLifetimeManager());
            container.RegisterType<ISchoolScheduleRoleManager, SchoolScheduleRoleManager>(new PerRequestLifetimeManager());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}