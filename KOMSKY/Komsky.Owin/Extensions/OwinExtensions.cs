using System;
using Komsky.Owin.Authorization;
using Owin;

namespace LendAngel.Owin.Extensions
{
    public static class OwinExtensions
    {
        public static void UseBasicAuthorizationCookie(this IAppBuilder app, BasicAuthorizationCookieOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            app.Use<BasicAuthorizationCookie>(options);
        }
    }
}
