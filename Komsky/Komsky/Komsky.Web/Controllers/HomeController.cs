using System;
using System.Threading;
using System.Web.Mvc;

namespace Komsky.Web.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            if (HttpContext.Cache["CurrentTime"] == null)
            {
                HttpContext.Cache.Insert("CurrentTime", ReadServerTime());
            }
            ViewBag.CurrentTime = HttpContext.Cache["CurrentTime"].ToString();
            ViewBag.Title = "Home";
            return View();
        }

        private string ReadServerTime()
        {
            Thread.Sleep(10000);
            return DateTime.Now.ToLongTimeString();
        }

        public virtual ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}