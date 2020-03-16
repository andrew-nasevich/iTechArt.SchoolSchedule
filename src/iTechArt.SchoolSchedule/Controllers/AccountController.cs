using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;
using iTechArt.SchoolSchedule.Models;
using iTechArt.SchoolSchedule.DomainModel.Users;
using iTechArt.SchoolSchedule.Foundation.Interfaces;

namespace iTechArt.SchoolSchedule.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISchoolScheduleUserManager _userManager;

        private IAuthenticationManager AuthManager => HttpContext.GetOwinContext().Authentication;


        public AccountController(ISchoolScheduleUserManager userManager)
        { 
            _userManager = userManager;
        }


        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Logout()
        {
            AuthManager.SignOut();

            return Redirect("/Account/Login");
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserLoginModel details)
        {
            var user = await _userManager.FindAsync(details.Name, details.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Некорректное имя или пароль.");
            }
            else
            {
                var ident = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

                AuthManager.SignOut();
                AuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);

                return Redirect("/Home/Index");
            }

            return View(details);
        }

        [HttpPost]
        public async Task<ActionResult> Register(UserRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new SchoolScheduleUser { UserName = model.Name, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return Redirect("/Home/Index");
                }

                AddErrorsFromResult(result);
            }

            return View(model);
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