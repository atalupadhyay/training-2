using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Komsky.Domain.Models;
using Komsky.Services.Handlers;
using Komsky.Web.Models;
using Komsky.Web.Models.Factories;
using Microsoft.AspNet.Identity;

namespace Komsky.Web.Controllers
{
    public partial class TicketController : Controller
    {
        private readonly IBaseHandler<TicketDomain> _ticketHandler;
        private readonly IBaseHandler<ProductDomain> _productHandler;

        public TicketController(IBaseHandler<TicketDomain> ticketHandler, IBaseHandler<ProductDomain> productHandler)
        {
            _ticketHandler = ticketHandler;
            _productHandler = productHandler;
        }

        public virtual ActionResult Index()
        {
            var model = _ticketHandler.GetAll().Select(TicketViewModelFactory.Create);
            return View(model);
        }

        // GET: Ticket/Details/5
        public virtual ActionResult Details(int id)
        {
            var model = _ticketHandler.GetById(id).CreateTicketViewModel();
            return View(model);
        }

        // GET: Ticket/Create
        public virtual ActionResult Create()
        {
            TicketViewModel model = new TicketViewModel();
            model.AllProducts = _productHandler.GetAll().Select(ProductViewModelFactory.Create);
            return View(model);
        }

        // POST: Ticket/Create
        [HttpPost]
        public virtual ActionResult Create([Bind(Include = "Title, Description, ProductId")] TicketViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.OwnerId = User.Identity.GetUserId();
                _ticketHandler.Add(model.CreateTicketDomain());
                _ticketHandler.Commit();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public virtual ActionResult Edit(int id)
        {
            var model = _ticketHandler.GetById(id);
            if (model != null)
            {
                return View(model.CreateTicketViewModel());
            }
            return HttpNotFound("Ticket not found");
        }

        [HttpPost]
        public virtual ActionResult Edit(TicketViewModel model)
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
        public virtual ActionResult Delete(int id)
        {
            var model = _ticketHandler.GetById(id).CreateTicketViewModel();
            return View(model);
        }

        // POST: Ticket/Delete/5
        [HttpPost]
        public virtual ActionResult Delete(TicketViewModel model)
        {
            _ticketHandler.Delete(model.Id);
            _ticketHandler.Commit();
            return RedirectToAction("Index");
        }
    }
}
