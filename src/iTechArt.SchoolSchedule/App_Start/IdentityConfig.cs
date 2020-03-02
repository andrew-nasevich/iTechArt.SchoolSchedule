using iTechArt.SchoolSchedule.Repositories.DbContexts;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using iTechArt.SchoolSchedule.DomainModel.Users;
using Microsoft.AspNet.Identity.Owin;
using iTechArt.SchoolSchedule.Foundation.SchoolScheduleManagers;
using iTechArt.SchoolSchedule.Foundation.SchoolScheduleStores;

namespace iTechArt.SchoolSchedule.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<SchoolScheduleAuthenticationContext>(SchoolScheduleAuthenticationContext.Create);
            app.CreatePerOwinContext<SchoolScheduleUserManager>(CreateSchoolScheduleUserManager);
            app.CreatePerOwinContext<SchoolScheduleRoleManager>(CreateSchoolScheduleRoleManager);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Admin/Login"),
            });
        }

        public static SchoolScheduleUserManager CreateSchoolScheduleUserManager(IdentityFactoryOptions<SchoolScheduleUserManager> options, IOwinContext context)
        {
            var db = context.Get<SchoolScheduleAuthenticationContext>();
            var manager = new SchoolScheduleUserManager(new SchoolScheduleUserStore<SchoolScheduleUser>(db));

            return manager;
        }

        public static SchoolScheduleRoleManager CreateSchoolScheduleRoleManager(IdentityFactoryOptions<SchoolScheduleRoleManager> options, IOwinContext context)
        {
            var db = context.Get<SchoolScheduleAuthenticationContext>();
            var manager = new SchoolScheduleRoleManager(new SchoolScheduleRoleStore<SchoolScheduleRole>(db));

            return manager;
        }
    }
}