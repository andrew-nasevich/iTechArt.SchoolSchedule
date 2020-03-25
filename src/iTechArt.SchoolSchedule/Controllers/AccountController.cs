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
        private readonly IAuthenticationManager _authManager;


        public AccountController(ISchoolScheduleUserManager userManager, IAuthenticationManager authManager)
        { 
            _userManager = userManager;
            _authManager = authManager;
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
            _authManager.SignOut();

            return Redirect("/Account/Login");
        }

        [HttpPost]
        public async Task<ActionResult> Login(UserLoginModel details)
        {
            var user = await _userManager.FindAsync(details.Name, details.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Invalid Name or Password.");
            }
            else
            {
                var ident = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

                _authManager.SignOut();
                _authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);

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
                    var ident = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

                    _authManager.SignOut();
                    _authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);

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