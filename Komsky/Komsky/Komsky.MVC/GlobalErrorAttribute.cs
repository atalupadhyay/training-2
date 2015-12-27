using System.Web.Mvc;
using NLog;

namespace Komsky.Mvc
{
    public class HandleGlobalErrorAttribute : HandleErrorAttribute
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public override void OnException(ExceptionContext filterContext)
        {
            var action = filterContext.RequestContext.RouteData.Values["action"] as string;
            var controller = filterContext.RequestContext.RouteData.Values["controller"] as string;
            Logger.Fatal(filterContext.Exception, "Site unexpected error");


            ////---- DOUBLE BROWSER TAB LOGIN ERROR ISSUE -----//
            //// See: http://stackoverflow.com/questions/19096723/login-request-validation-token-issue
            //if ((filterContext.Exception is HttpAntiForgeryException) &&
            //    (action == "ExternalLogin" || action == "Login" || action == "Register") &&
            //    controller == "Account" &&
            //    filterContext.RequestContext.HttpContext.User != null &&
            //    filterContext.RequestContext.HttpContext.User.Identity.IsAuthenticated)
            //{
            //    Logger.Warn("Handled AntiForgery exception because user is already Authenticated: " + filterContext.Exception.Message, filterContext.Exception);
            //    filterContext.ExceptionHandled = true;
            //    filterContext.Result = new RedirectResult("/");
            //}
            //else
            //{
            //    Logger.FatalException("Site unexpected error", filterContext.Exception);
            //}
            ////----------------------------------------------//
            base.OnException(filterContext);
        }
    }
}
