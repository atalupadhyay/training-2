﻿using System;
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
            ViewBag.Title = "Home";
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

    }
}