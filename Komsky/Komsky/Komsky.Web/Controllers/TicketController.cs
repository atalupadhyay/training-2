using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Komsky.Domain.Models;
using Komsky.Services.Handlers;
using Komsky.Web.Models;
using Komsky.Web.Models.Factories;
using Komsky.Mvc;

namespace Komsky.Web.Controllers
{
    public partial class TicketController : Controller
    {
        private readonly ITicketHandler _ticketHandler;
        private readonly IBaseHandler<ProductDomain> _productHandler;
        private readonly ICurrentUser _currentUser;

        public TicketController(ITicketHandler ticketHandler, IBaseHandler<ProductDomain> productHandler, ICurrentUser currentUser)
        {
            _ticketHandler = ticketHandler;
            _productHandler = productHandler;
            _currentUser = currentUser;
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
                model.OwnerId = _currentUser.GetUserId();
                _ticketHandler.Add(model.CreateTicketDomain());
                _ticketHandler.Commit();
                return RedirectToAction("Index");
            }
            model.AllProducts = _productHandler.GetAll().Select(ProductViewModelFactory.Create);
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

        public virtual ActionResult Search(string searchterm)
        {
            IEnumerable<TicketViewModel> foundTickets = _ticketHandler.SearchTickets(searchterm).Select(TicketViewModelFactory.Create);
            ViewBag.Title = "Search results";
            if (foundTickets.Any())
            {
                ViewBag.Message = "Following tickets were matching your criteria:";
            }
            else
            {
                ViewBag.Message = "No tickets found";
            }
            return View(MVC.Ticket.Views.Index, foundTickets);
        }

        #region AJAX
        [HttpGet]
        public virtual PartialViewResult TicketModal(int id)
        {
            var model = _ticketHandler.GetById(id).CreateTicketViewModel();
            return PartialView(MVC.Ticket.Views._Ticket, model);
        }
        #endregion
    }
}
