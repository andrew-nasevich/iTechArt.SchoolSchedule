using iTechArt.SchoolSchedule.App_Start;
using Microsoft.Owin.Security;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;
using Unity.Resolution;

namespace iTechArt.SchoolSchedule.SchoolScheduleControllerFactories
{
    public class SchoolScheduleControllerFactory : DefaultControllerFactory
    {
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controllerType = GetControllerType(requestContext, controllerName);
            var constructors = controllerType.GetConstructors();

            var hasAuthManagerParam = false;
            var authManegerParamName = "";
            foreach(var c in constructors)
            {
                foreach(var p in c.GetParameters())
                {
                    if(p.ParameterType == typeof(IAuthenticationManager))
                    {
                        hasAuthManagerParam = true;
                        authManegerParamName = p.Name;
                    }
                }
            }

            if(hasAuthManagerParam)
            {
                var authManager = requestContext.HttpContext.GetOwinContext().Authentication;
                
                return (IController)UnityConfig.UnityContainer.Resolve(controllerType, new ParameterOverride(authManegerParamName, authManager));
            }

            return base.CreateController(requestContext, controllerName);
        }
    }
}