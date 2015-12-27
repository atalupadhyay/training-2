using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Komsky.Data.DataAccess.UnitOfWork;

namespace Komsky.Web.Controllers
{
    public partial class HomeController : Controller
    {
        private readonly IDataFacade _dataFacade;

        public HomeController(IDataFacade dataFacade)
        {
            _dataFacade = dataFacade;
        }


        public virtual ActionResult Index()
        {

            if (User != null && User.Identity != null && !String.IsNullOrEmpty(User.Identity.Name))
            {
                ViewBag.UserDetails = _dataFacade.ApplicationUsers.GetByEmail(User.Identity.Name).Email;
            }
            return View();
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

        public virtual ActionResult Error()
        {
            throw new ApplicationException("Simulating fatal and unexpected error");
            return View(MVC.Home.Views.Index);
        }
    }
}