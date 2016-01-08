using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Komsky.Data.DataAccess.UnitOfWork;
using System.Threading;

namespace Komsky.Web.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly IDataFacade _dataFacade;
        private readonly IMemoryCacheService _memoryCache;

        public HomeController(IDataFacade dataFacade, IMemoryCacheService memoryCache)
        {
            _dataFacade = dataFacade;
            _memoryCache = memoryCache;
        }

        public virtual ActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }

        //[OutputCache(Duration = 30, VaryByParam="User")]
        public virtual ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.ServerTime = GetServerTime();
            return View();
        }

        private dynamic GetServerTime()
        {

            if (!_memoryCache.MemoryCache.Contains("ServerTime"))
            {
                Thread.Sleep(10000); //this is just for simulating long-running job
                _memoryCache.MemoryCache.Add(new System.Runtime.Caching.CacheItem("ServerTime", DateTime.Now.ToLongTimeString()), new System.Runtime.Caching.CacheItemPolicy());
            }
            String serverTime = _memoryCache.MemoryCache.Get("ServerTime").ToString();
            return serverTime;
        }

        public virtual ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public virtual PartialViewResult Baner()
        {
            Random losowy = new Random();
            int wynik = losowy.Next(1, 10);
            ViewBag.Banner = "Dziś wygrał numer: " + wynik;
            return PartialView("_Baner");

        }

        public virtual String SessionApp(string id)
        {
            if (HttpContext.Application["id"] == null)
            {
                HttpContext.Application["id"] = id;
            }

            return HttpContext.Application["id"].ToString();
        }

        #region AJAX
        public virtual JsonResult LoadTickets()
        {
            try
            {
                var ileTicketów = _dataFacade.Tickets.GetAll().Count();
                String result = String.Format("Masz {0} ticketów w bazie", ileTicketów);
                return Json(new { Success = true, Data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { Success = false }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

    }
}