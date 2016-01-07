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

        [OutputCache(Duration = 30)]
        public virtual ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.ServerTime = GetSErverTime();
            return View();
        }

        private dynamic GetSErverTime()
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

    }
}