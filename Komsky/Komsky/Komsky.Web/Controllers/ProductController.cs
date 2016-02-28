﻿using System;
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
    [Authorize]
    public partial class ProductController : Controller
    {
        private readonly IBaseHandler<ProductDomain> _productHandler;
        private readonly IBaseHandler<CustomerDomain> _customerHandler;
        private readonly ITicketHandler _ticketHandler;

        public ProductController(IBaseHandler<ProductDomain> productHandler, IBaseHandler<CustomerDomain> customerHandler, ITicketHandler ticketHandler)
        {
            _productHandler = productHandler;
            _customerHandler = customerHandler;
            _ticketHandler = ticketHandler;
        }

        // GET: Product
        public virtual ActionResult Index()
        {
            var model = _productHandler.GetAll().Select(ProductViewModelFactory.Create);
            return View(model);
        }

        [Route("Product/{id}")]
        public virtual ActionResult Details(int id)
        {
            var model = _productHandler.GetById(id);
            if (model != null)
            {
                return View(model.CreateProductViewModel());
            }
            return HttpNotFound();
        }

        public virtual ActionResult Create()
        {
            ProductViewModel model = new ProductViewModel();
            model.AllCustomers = _customerHandler.GetAll().Select(CustomerViewModelFactory.Create);
            return View(model);
        }

        [HttpPost]
        public virtual ActionResult Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productHandler.Add(model.CreateProductDomain());
                _productHandler.Commit();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public virtual ActionResult Edit(int id)
        {
            var domain = _productHandler.GetById(id);
            if (domain != null)
            {
                var model = domain.CreateProductViewModel();
                model.AllCustomers = _customerHandler.GetAll().Select(CustomerViewModelFactory.Create);
                return View(model);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public virtual ActionResult Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                _productHandler.Update(model.CreateProductDomain());
                _productHandler.Commit();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public virtual ActionResult Delete(int id)
        {
            var model = _productHandler.GetById(id);
            if (model != null)
            {
                return View(model.CreateProductViewModel());
            }
            return HttpNotFound();
        }

        [HttpPost]
        public virtual ActionResult Delete(ProductViewModel model)
        {
            _productHandler.Delete(model.Id);
            _productHandler.Commit();
            return RedirectToAction("Index");
        }

        [Route("Product/{id}/Tickets")]
        public virtual ActionResult Tickets(int id)
        {
            IEnumerable<TicketViewModel> ticketsForProduct =
                _ticketHandler.TicketsForProduct(id).Select(TicketViewModelFactory.Create);
            var thisProduct = _productHandler.GetById(id);
            ViewBag.Title = thisProduct.Name +" product tickets";
            if (ticketsForProduct.Any())
            {
                ViewBag.Message = "Following tickets were created for this product:";
            }
            else
            {
                ViewBag.Message = "No tickets were created for this product";
            }
            return View(MVC.Ticket.Views.Index, ticketsForProduct);
        }
    }
}
