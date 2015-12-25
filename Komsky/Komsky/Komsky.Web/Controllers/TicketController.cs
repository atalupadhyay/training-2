using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Komsky.Domain.Models;
using Komsky.Services.Handlers;
using Komsky.Web.Models;
using Komsky.Web.Models.Factories;

namespace Komsky.Web.Controllers
{
    public class TicketController : Controller
    {
        private readonly IBaseHandler<TicketDomain> _ticketHandler;

        public TicketController(IBaseHandler<TicketDomain> ticketHandler)
        {
            _ticketHandler = ticketHandler;
        }

        public ActionResult Index()
        {
            var model = _ticketHandler.GetAll().Select(TicketViewModelFactory.Create);
            return View(model);
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int id)
        {
            var model = _ticketHandler.GetById(id).CreateTicketViewModel();
            return View(model);
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ticket/Create
        [HttpPost]
        public ActionResult Create(TicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                _ticketHandler.Add(model.CreateTicketDomain());
                _ticketHandler.Commit();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var model = _ticketHandler.GetById(id);
            if (model != null)
            {
                return View(model.CreateTicketViewModel());
            }
            return HttpNotFound("Ticket not found");
        }

        [HttpPost]
        public ActionResult Edit(TicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                _ticketHandler.Update(model.CreateTicketDomain());
                _ticketHandler.Commit();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Ticket/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _ticketHandler.GetById(id).CreateTicketViewModel();
            return View(model);
        }

        // POST: Ticket/Delete/5
        [HttpPost]
        public ActionResult Delete(TicketViewModel model)
        {
            _ticketHandler.Delete(model.Id);
            _ticketHandler.Commit();
            return RedirectToAction("Index");
        }
    }
}
