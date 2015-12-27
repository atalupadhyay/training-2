using System;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Komsky.Mvc
{
    public interface ICurrentUser
    {
        String Name { get; }
        String GetUserId();
    }

    public class CurrentUser : ICurrentUser
    {
        public string Name
        {
            get { return HttpContext.Current.User.Identity.Name; }
        }
        public string GetUserId()
        {
            return HttpContext.Current.User.Identity.GetUserId();
        }
    }
}
