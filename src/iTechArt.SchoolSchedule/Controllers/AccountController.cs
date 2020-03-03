using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using iTechArt.SchoolSchedule.Models;
using iTechArt.SchoolSchedule.DomainModel.Users;
using iTechArt.SchoolSchedule.Foundation.SchoolScheduleManagers;
using iTechArt.SchoolSchedule.Foundation.Interfaces;

namespace iTechArt.SchoolSchedule.Controllers
{
    public class AccountController : Controller
    {
        private IAuthenticationManager AuthManager => HttpContext.GetOwinContext().Authentication;

        private ISchoolScheduleUserManager UserManager => HttpContext.GetOwinContext().GetUserManager<SchoolScheduleUserManager>();


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel details)
        {
            SchoolScheduleUser user = await UserManager.FindAsync(details.Name, details.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Некорректное имя или пароль.");
            }
            else
            {
                ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);

                AuthManager.SignOut();
                AuthManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false
                }, ident);

                return Redirect("/Home/Index");
            }

            return View(details);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                SchoolScheduleUser user = new SchoolScheduleUser { UserName = model.Name, Email = model.Email };
                IdentityResult result =
                    await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return Redirect("/Home/Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(model);
        }

        public async Task<ActionResult> Logout()
        {
            AuthManager.SignOut();
            return Redirect("/Account/Login");
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}