namespace Komsky.Owin.Authorization
{
    public class BasicAuthorizationCookieOptions
    {
        public const string BasicAuthorizationCookieName = "BasicAuthorizationCookie";
        public string LocalPath { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string[] AllowedPaths { get; set; }
    }
}
