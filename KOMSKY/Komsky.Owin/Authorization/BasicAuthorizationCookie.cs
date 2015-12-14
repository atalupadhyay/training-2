using System;
using System.Linq;
using System.Threading.Tasks;
using Komsky.Helpers;
using Microsoft.Owin;

namespace Komsky.Owin.Authorization
{
    /// <summary>
    /// Allows us to use custom site wide passwords and prevent 404.15 errors as 
    /// explained here: http://stackoverflow.com/questions/24919919/owin-authentication-with-iis-basic-authentication
    /// There is no point using basic authentication as we want authorization
    /// </summary>
    public class BasicAuthorizationCookie : OwinMiddleware
    {        
        private readonly BasicAuthorizationCookieOptions _options;

        public BasicAuthorizationCookie(OwinMiddleware next, BasicAuthorizationCookieOptions options)
            : base(next)
        {
            _options = options;
        }

        public override async Task Invoke(IOwinContext context)
        {
            string cookieName = GetCookieName(context.Request.Uri);
            var cookie = context.Request.Cookies[cookieName];

            bool isCookieValueCorrect = cookie.ToBase64Decode() == string.Format(
                "{0}{1}",
                _options.UserName,
                _options.Password);

            bool isUrlSecurityAccessUrl = context.Request.Uri.LocalPath == _options.LocalPath;

            bool isUrlAnAllowedUrl = _options.AllowedPaths != null &&
                                     _options.AllowedPaths.Any(context.Request.Path.Value.Contains);

            if (!isCookieValueCorrect &&
                !isUrlSecurityAccessUrl &&                
                !isUrlAnAllowedUrl)
            {                
                context.Response.Redirect(_options.LocalPath);
                return;
            }
            
            await Next.Invoke(context);            
        }
        
        public static string GetCookieName(Uri request)
        {
            if (request == null)
            {
                return string.Empty;
            }            

            return string.Format(
                "{0}{1}{2}", 
                BasicAuthorizationCookieOptions.BasicAuthorizationCookieName,
                request.Host,
                request.Port);
        }

    }

    
}
