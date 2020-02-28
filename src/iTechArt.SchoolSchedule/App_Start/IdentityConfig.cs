using iTechArt.SchoolSchedule.Repositories.DbContexts;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using iTechArt.SchoolSchedule.Repositories.IdentityModels.ApplicationManagers;
using Microsoft.AspNet.Identity.Owin;
using iTechArt.SchoolSchedule.Repositories.IdentityModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace iTechArt.SchoolSchedule.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<SchoolScheduleAuthenticationContext>(SchoolScheduleAuthenticationContext.Create);
            app.CreatePerOwinContext<SchoolScheduleUserManager>(CreateSchoolScheduleUserManager);
            // TODO: Why do you need it
            app.CreatePerOwinContext<SchoolScheduleRoleManager>(CreateSchoolScheduleRoleManager);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Admin/Login"),
            });
        }

        public static SchoolScheduleUserManager CreateSchoolScheduleUserManager(IdentityFactoryOptions<SchoolScheduleUserManager> options, IOwinContext context)
        {
            SchoolScheduleAuthenticationContext db = context.Get<SchoolScheduleAuthenticationContext>();
            SchoolScheduleUserManager manager = new SchoolScheduleUserManager(new UserStore<SchoolScheduleUser>(db));

            return manager;
        }

        public static SchoolScheduleRoleManager CreateSchoolScheduleRoleManager(
            IdentityFactoryOptions<SchoolScheduleRoleManager> options,
            IOwinContext context)
        {
            return new SchoolScheduleRoleManager(new RoleStore<SchoolScheduleRole>(context.Get<SchoolScheduleAuthenticationContext>()));
        }
    }
}