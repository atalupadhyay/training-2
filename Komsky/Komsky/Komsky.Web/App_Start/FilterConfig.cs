using System.Web.Mvc;
using Komsky.Mvc;

namespace Komsky.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleGlobalErrorAttribute());
        }
    }
}
